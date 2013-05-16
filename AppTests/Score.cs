using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.Foundation;

using Windows.UI.Xaml;


namespace AppTests
{
    public class Score
    {
        private Double points;
        private String time;
        private String levelName;

        public Double Points
        {
            set { this.points = value; }
            get { return this.points; }
        }

        public String Time
        {
            set { this.time = value; }
            get { return this.time; }
        }

        public String LevelName
        {
            set { this.levelName = value; }
            get { return this.levelName; }
        }

        private Int32 levelRank
        {
            get
            {
                if (LevelName.CompareTo("łatwy") == 0) return 0;
                else if (LevelName.CompareTo("normalny") == 0) return 5;
                else return 10;
            }
        }

        Score() { }

        public Score(Double p, String t, String ln)
        {
            this.Points = p;
            this.Time = t;
            this.LevelName = ln;
        }

        public Score(ScoreAnemic score)
        {
            this.Points = score.points;
            this.Time = score.time;
            this.LevelName = score.levelName;
        }

        public static int sortByScoreAndLevel(Score s1, Score s2)
        {
            if (s1.Points > s2.Points) return -1;
            else if (s1.Points < s2.Points) return 1;
            else
            {
                if (s1.levelRank > s2.levelRank) return -1;
                else if (s1.levelRank < s2.levelRank) return 1;
                else return 0;
            }
        }
    }

    public class ScoresList : List<Score>
    {
        App thisApp = Application.Current as App;
        public ScoresList()
        {
            /*Add(new Score(500, DateTime.Now.ToString("dd.MM.yyyy HH:mm"), "normalny"));
            Add(new Score(501, DateTime.Now.ToString("dd.MM.yyyy HH:mm"), "trudny"));
            Add(new Score(500, DateTime.Now.ToString("dd.MM.yyyy HH:mm"), "normalny"));
            Add(new Score(501, DateTime.Now.ToString("dd.MM.yyyy HH:mm"), "łatwy"));*/
           
        }

        public void addScore(Score s)
        {
            Add(s);
            StorageProxy.writeToFile("scores.xml", thisApp.scoreList);
        }

        public void clearScores()
        {
            Clear();
            StorageProxy.writeToFile("scores.xml", thisApp.scoreList);
        }


    }

    [DataContract]
    public class ScoreAnemic
    {
        [DataMember()]
        public Double points;
        [DataMember()]
        public String time;
        [DataMember()]
        public String levelName;

        public ScoreAnemic() { }

        public ScoreAnemic(Score score)
        {
            this.points = score.Points;
            this.time = score.Time;
            this.levelName = score.LevelName;
        }

    }
}
