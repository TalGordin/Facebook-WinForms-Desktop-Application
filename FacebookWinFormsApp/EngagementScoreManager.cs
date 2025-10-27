using System;
using System.Text;
using System.Windows.Forms;
using Facebook;
using System.Threading.Tasks;

namespace BasicFacebookFeatures
{
    public class EngagementScoreManager : IFacebookManager
    {
        enum e_Weight
        {
            Reaction = 1,
            Comment = 3,
            Post = 5,
        }
        private static EngagementScoreManager s_Instance = null;
        private static readonly object s_Lock = new object();

        private TextBox m_EngagementScore;
        private Label m_EngagementDetails;

        private EngagementScoreManager(TextBox i_EngagementScore, Label i_EngagementDetails)
        {
            m_EngagementScore = i_EngagementScore;
            m_EngagementDetails = i_EngagementDetails;
        }

        public static EngagementScoreManager Instance(TextBox i_EngagementScore, Label i_EngagementDetails)
        {
            if (s_Instance == null)
            {
                lock (s_Lock)
                {
                    if (s_Instance == null)
                    {
                        s_Instance = new EngagementScoreManager(i_EngagementScore, i_EngagementDetails);
                    }
                }
            }
            return s_Instance;
        }

        public void Initialize()
        {
        }

        public async void DisplayEngagementDetails(string i_UserAccessToken, int i_AppWidth)
        {
            var EngagementDetailsCalculationResult = await calculateEngagementDetails(i_UserAccessToken);
            string engagementDetails = EngagementDetailsCalculationResult.ScoreDetails;
            m_EngagementScore.Text = EngagementDetailsCalculationResult.EngagementScore;
            m_EngagementDetails.Text = engagementDetails;
            m_EngagementDetails.Left = (i_AppWidth - m_EngagementDetails.Width) / 2;
        }

        private async Task<(string EngagementScore, string ScoreDetails)> calculateEngagementDetails(string i_UserAccessToken)
        {
            string startDate = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
            int allPostsAmount;
            int allCommentsAmount = 0;
            int allReactionsAmount = 0;
            int userReactionsCounter = 0;
            int userCommentsCounter = 0;
            int userPostsCounter = 0;
            StringBuilder sb = new StringBuilder();
            var fbClient = new FacebookClient(i_UserAccessToken);
            dynamic getUserInfoAsync = await fbClient.GetTaskAsync("/me");
            string userId = getUserInfoAsync.id;

            //Fetch posts:
            dynamic postsResult = await fbClient.GetTaskAsync($"/me/posts?since={startDate}");

            allPostsAmount = postsResult.data.Count;
            countUserOwnership(userId, ref userPostsCounter, postsResult.data);
            foreach (var post in postsResult.data)
            {
                //Fetch comments for posts:
                dynamic commentsResult = await fbClient.GetTaskAsync($"/{post.id}/comments");

                allCommentsAmount += commentsResult.data.Count;
                countUserOwnership(userId, ref userCommentsCounter, commentsResult.data);
                foreach (var comment in commentsResult.data)
                {
                    //Fetch reactions for comments:
                    dynamic reactionsOnCommentResult = await fbClient.GetTaskAsync($"/{comment.id}/reactions");

                    allReactionsAmount += reactionsOnCommentResult.data.Count;
                    countUserOwnership(userId, ref userReactionsCounter, reactionsOnCommentResult.data);
                }

                //Fetch reactions for posts:
                dynamic reactionsOnPostResult = await fbClient.GetTaskAsync($"/{post.id}/reactions");

                allReactionsAmount += reactionsOnPostResult.data.Count;
                countUserOwnership(userId, ref userReactionsCounter, reactionsOnPostResult.data);
            }

            //Calculate engagement score
            int totalEngagementScore =
                (allPostsAmount * (int)e_Weight.Post) +
                (allCommentsAmount * (int)e_Weight.Comment) +
                (allReactionsAmount * (int)e_Weight.Reaction);

            sb.AppendLine($"Details:");
            sb.AppendLine($"{allPostsAmount} posts were added to your wall");
            sb.AppendLine($"(including {userPostsCounter} made by you)");
            sb.AppendLine($"{allCommentsAmount} comments were added to those posts");
            sb.AppendLine($"(including {userCommentsCounter} made by you)");
            sb.AppendLine($"{allReactionsAmount} reactions were added to those posts and comments");
            sb.AppendLine($"(including {userReactionsCounter} made by you)");

            string engagementScore = totalEngagementScore.ToString();
            string engagementDetails = sb.ToString();

            return (engagementScore, engagementDetails);
        }

        private static void countUserOwnership(string i_UserID, ref int io_OwnershipCounter, dynamic i_Engagements)
        {
            if (i_Engagements != null)
            {
                foreach (var engagement in i_Engagements)
                {
                    if (engagement.from != null && engagement.from.id == i_UserID)
                    {
                        io_OwnershipCounter++;
                    }
                }
            }
        }
    }
}

