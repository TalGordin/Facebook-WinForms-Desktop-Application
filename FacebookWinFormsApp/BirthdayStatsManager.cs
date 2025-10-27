using System;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public class BirthdayStatsManager : IFacebookManager
    {
        private static BirthdayStatsManager s_Instance = null; //Singleton instance
        private static readonly object s_Lock = new object();
        private Label m_Title;
        private Label m_Details;

        private BirthdayStatsManager(Label i_Title, Label i_Details)
        {
            m_Title = i_Title;
            m_Details = i_Details;
        }

        public static BirthdayStatsManager Instance(Label i_Title, Label i_Details)
        {
            if (s_Instance == null)
            {
                lock (s_Lock)
                {
                    if (s_Instance == null)
                    {
                        s_Instance = new BirthdayStatsManager(i_Title, i_Details);
                    }
                }
            }
            return s_Instance;
        }

        public void Initialize()
        {
            m_Title.Text = string.Empty;
            m_Details.Text = string.Empty;
        }

        public void DisplayStats(User i_User, int i_AppWidth)
        {
            if (string.IsNullOrEmpty(i_User.Birthday))
            {
                m_Details.Text = "Birthday information is not available.";
                m_Title.Text = "No birthday data";
                return;
            }

            m_Details.Text = getStats(i_User, out string dateOfBirth);
            m_Title.Text = "Your birthday is on\n" + dateOfBirth;
            m_Details.Left = (i_AppWidth - m_Details.Width) / 2;
            m_Title.Left = (i_AppWidth - m_Title.Width) / 2;
        }

        private string getStats(User i_User, out string o_DateOfBirth)
        {
            o_DateOfBirth = i_User.Birthday;

            DateTime userDOB = DateTime.ParseExact(i_User.Birthday, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            DateTime miaTalericoDOB = DateTime.ParseExact("09/17/2008", "MM/dd/yyyy", CultureInfo.InvariantCulture);
            DateTime tomHollandDOB = DateTime.ParseExact("06/01/1996", "MM/dd/yyyy", CultureInfo.InvariantCulture);
            DateTime taylorSwiftDOB = DateTime.ParseExact("12/13/1989", "MM/dd/yyyy", CultureInfo.InvariantCulture);
            DateTime jenniferAnistonDOB = DateTime.ParseExact("02/11/1969", "MM/dd/yyyy", CultureInfo.InvariantCulture);
            DateTime morganFreemanDOB = DateTime.ParseExact("06/01/1937", "MM/dd/yyyy", CultureInfo.InvariantCulture);
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(calculateAge(userDOB));
            sb.AppendLine(getTimeSinceLastBirthdayString(userDOB));
            sb.AppendLine(getTimeUntilNextBirthdayString(userDOB));
            sb.AppendLine();
            sb.AppendLine(getLifeLength(userDOB));
            sb.AppendLine();
            sb.AppendLine("You are...");
            sb.AppendLine(compareWithCelebrity(userDOB, miaTalericoDOB, "Mia Talerico"));
            sb.AppendLine(compareWithCelebrity(userDOB, tomHollandDOB, "Tom Holland"));
            sb.AppendLine(compareWithCelebrity(userDOB, taylorSwiftDOB, "Taylor Swift"));
            sb.AppendLine(compareWithCelebrity(userDOB, jenniferAnistonDOB, "Jennifer Aniston"));
            sb.AppendLine(compareWithCelebrity(userDOB, morganFreemanDOB, "Morgan Freeman"));

            return sb.ToString();
        }

        private string compareWithCelebrity(DateTime i_DateOfBirth, DateTime i_CelebrityDateOfBirth, string i_CelebrityName)
        {
            int comparison = DateTime.Compare(i_DateOfBirth, i_CelebrityDateOfBirth);
            if (comparison < 0)
            {
                return $"Older than {i_CelebrityName}.";
            }
            else if (comparison > 0)
            {
                return $"Younger than {i_CelebrityName}.";
            }
            else
            {
                return $"The same age as {i_CelebrityName}!";
            }
        }

        private string getLifeLength(DateTime i_DateOfBirth)
        {
            DateTime now = DateTime.Now;
            int years = now.Year - i_DateOfBirth.Year;
            int months = now.Month - i_DateOfBirth.Month;
            int days = now.Day - i_DateOfBirth.Day;

            if (days < 0)
            {
                months--;
                days += DateTime.DaysInMonth(now.Year, now.Month);
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            int totalMonths = (years * 12) + months;
            TimeSpan totalDays = now - i_DateOfBirth;

            return $"You've been alive for {years} years,\n" +
                $"Which are {totalMonths} months,\n" +
                $"Which are {totalDays.Days} days!";
        }

        private string calculateAge(DateTime i_DateOfBirth)
        {
            DateTime now = DateTime.Now;
            int years = now.Year - i_DateOfBirth.Year;
            int months = now.Month - i_DateOfBirth.Month;
            int days = now.Day - i_DateOfBirth.Day;

            if (days < 0)
            {
                months--;
                days += DateTime.DaysInMonth(now.Year, now.Month);
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            return $"You are {years} years, {months} months, and {days} days old";
        }

        private string getTimeSinceLastBirthdayString(DateTime i_DateOfBirth)
        {
            TimeSpan timeSinceLastBirthday = calculateTimeSinceLastBirthday(i_DateOfBirth);
            return $"It's been {timeSinceLastBirthday.Days} days since your last birthday.";
        }

        private string getTimeUntilNextBirthdayString(DateTime i_DateOfBirth)
        {
            TimeSpan timeUntilNextBirthday = calculateTimeUntilNextBirthday(i_DateOfBirth);
            return $"Your next birthday is in {timeUntilNextBirthday.Days} days.";
        }

        private TimeSpan calculateTimeSinceLastBirthday(DateTime i_DateOfBirth)
        {
            DateTime now = DateTime.Now;
            DateTime lastBirthday = new DateTime(now.Year, i_DateOfBirth.Month, i_DateOfBirth.Day);

            if (lastBirthday > now)
            {
                lastBirthday = lastBirthday.AddYears(-1);
            }

            return now - lastBirthday;
        }

        private TimeSpan calculateTimeUntilNextBirthday(DateTime i_DateOfBirth)
        {
            DateTime now = DateTime.Now;
            DateTime nextBirthday = new DateTime(now.Year, i_DateOfBirth.Month, i_DateOfBirth.Day);

            if (nextBirthday < now)
            {
                nextBirthday = nextBirthday.AddYears(+1);
            }

            return nextBirthday - now;
        }
    }
}
