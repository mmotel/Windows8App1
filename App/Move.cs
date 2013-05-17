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


namespace AppTests
{

    public class Move : INotifyPropertyChanged
    {
        public Move(int move1, int move2, int move3, int move4, int move5)
        {
            this.black = 0;
            this.white = 0;
            this.value1 = move1;
            this.value2 = move2;
            this.value3 = move3;
            this.value4 = move4;
            this.value5 = move5;
        }

        public Move(int move1, int move2, int move3)
        {
            this.black = 0;
            this.white = 0;
            this.value1 = move1;
            this.value2 = move2;
            this.value3 = move3;
            this.value4 = 0;
            this.value5 = 0;
        }

        public Move()
        {
            this.black = 0;
            this.white = 0;
            this.value1 = -1;
            this.value2 = 0;
            this.value3 = 0;
            this.value4 = 0;
            this.value5 = 0;
        }

        public Move(MoveAnemic newMove)
        {
            this.value1 = newMove.value1;
            this.value2 = newMove.value2;
            this.value3 = newMove.value3;
            this.value4 = newMove.value4;
            this.value5 = newMove.value5;
            this.black = newMove.black;
            this.white = newMove.white;
        }

        public Move(MoveAnemic newMove, int add, int multi)
        {
            this.value1 = (newMove.value1 / multi) - add;
            this.value2 = (newMove.value2 / multi) - add;
            this.value3 = (newMove.value3 / multi) - add;
            this.value4 = (newMove.value4 / multi) - add;
            this.value5 = (newMove.value5 / multi) - add;
            this.black = newMove.black;
            this.white = newMove.white;
        }


        public event PropertyChangedEventHandler PropertyChanged;


        private int value1;

        private int value2;

        private int value3;

        private int value4;

        private int value5;


        private int black;

        private int white;

        public int White
        {
            set { this.white = value; }
            get { return this.white; }
        }
        public int Black
        {
            set { this.black = value; }
            get { return this.black; }
        }
        public int Value1
        {
            set
            {
                value1 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Value1"));
                PropertyChanged(this, new PropertyChangedEventArgs("Value1Color"));
                PropertyChanged(this, new PropertyChangedEventArgs("Value1EasyPrevColor"));
                PropertyChanged(this, new PropertyChangedEventArgs("Value1EasyNextColor"));
                PropertyChanged(this, new PropertyChangedEventArgs("Value1NormalPrevColor"));
                PropertyChanged(this, new PropertyChangedEventArgs("Value1NormalNextColor"));
                PropertyChanged(this, new PropertyChangedEventArgs("Value1HardPrevColor"));
                PropertyChanged(this, new PropertyChangedEventArgs("Value1HardNextColor"));
            }
            get { return value1; }
        }
        public int Value2
        {
            set
            {
                value2 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Value2"));
                PropertyChanged(this, new PropertyChangedEventArgs("Value2Color"));
                PropertyChanged(this, new PropertyChangedEventArgs("Value2EasyPrevColor"));
                PropertyChanged(this, new PropertyChangedEventArgs("Value2EasyNextColor"));
                PropertyChanged(this, new PropertyChangedEventArgs("Value2NormalPrevColor"));
                PropertyChanged(this, new PropertyChangedEventArgs("Value2NormalNextColor"));
                PropertyChanged(this, new PropertyChangedEventArgs("Value2HardPrevColor"));
                PropertyChanged(this, new PropertyChangedEventArgs("Value2HardNextColor"));
            }
            get { return value2; }
        }
        public int Value3
        {
            set
            {
                value3 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Value3"));
                PropertyChanged(this, new PropertyChangedEventArgs("Value3Color"));
                PropertyChanged(this, new PropertyChangedEventArgs("Value3EasyPrevColor"));
                PropertyChanged(this, new PropertyChangedEventArgs("Value3EasyNextColor"));
                PropertyChanged(this, new PropertyChangedEventArgs("Value3NormalPrevColor"));
                PropertyChanged(this, new PropertyChangedEventArgs("Value3NormalNextColor"));
                PropertyChanged(this, new PropertyChangedEventArgs("Value3HardPrevColor"));
                PropertyChanged(this, new PropertyChangedEventArgs("Value3HardNextColor"));
            }
            get { return value3; }
        }
        public int Value4
        {
            set
            {
                value4 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Value4"));
                PropertyChanged(this, new PropertyChangedEventArgs("Value4Color"));
                PropertyChanged(this, new PropertyChangedEventArgs("Value4NormalPrevColor"));
                PropertyChanged(this, new PropertyChangedEventArgs("Value4NormalNextColor"));
                PropertyChanged(this, new PropertyChangedEventArgs("Value4HardPrevColor"));
                PropertyChanged(this, new PropertyChangedEventArgs("Value4HardNextColor"));
            }
            get { return value4; }
        }
        public int Value5
        {
            set
            {
                value5 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Value5"));
                PropertyChanged(this, new PropertyChangedEventArgs("Value5Color"));
                PropertyChanged(this, new PropertyChangedEventArgs("Value5NormalPrevColor"));
                PropertyChanged(this, new PropertyChangedEventArgs("Value5NormalNextColor"));
                PropertyChanged(this, new PropertyChangedEventArgs("Value5HardPrevColor"));
                PropertyChanged(this, new PropertyChangedEventArgs("Value5HardNextColor"));
            }
            get { return value5; }
        }

        public String Value1Color
        {
            get
            {
                return colorFromValue(Value1);
            }
        }
        public String Value2Color
        {
            get
            {
                return colorFromValue(Value2);
            }
        }
        public String Value3Color
        {
            get
            {
                return colorFromValue(Value3);
            }
        }
        public String Value4Color
        {
            get
            {
                return colorFromValue(Value4);
            }
        }
        public String Value5Color
        {
            get
            {
                return colorFromValue(Value5);
            }
        }
        //Next & Prev colors for EASY level
        public String Value1EasyPrevColor
        {
            get
            {
                return colorFromValue((Value1+2)%3);
            }
        }
        public String Value2EasyPrevColor
        {
            get
            {
                return colorFromValue((Value2 + 2) % 3);
            }
        }
        public String Value3EasyPrevColor
        {
            get
            {
                return colorFromValue((Value3 + 2) % 3);
            }
        }

        public String Value1EasyNextColor
        {
            get
            {
                return colorFromValue((Value1 + 1) % 3);
            }
        }
        public String Value2EasyNextColor
        {
            get
            {
                return colorFromValue((Value2 + 1) % 3);
            }
        }
        public String Value3EasyNextColor
        {
            get
            {
                return colorFromValue((Value3 + 1) % 3);
            }
        }
        //Next & Prev colors for NORMAL level
        public String Value1NormalPrevColor
        {
            get
            {
                return colorFromValue((Value1 + 4) % 5);
            }
        }
        public String Value2NormalPrevColor
        {
            get
            {
                return colorFromValue((Value2 + 4) % 5);
            }
        }
        public String Value3NormalPrevColor
        {
            get
            {
                return colorFromValue((Value3 + 4) % 5);
            }
        }
        public String Value4NormalPrevColor
        {
            get
            {
                return colorFromValue((Value4 + 4) % 5);
            }
        }
        public String Value5NormalPrevColor
        {
            get
            {
                return colorFromValue((Value5 + 4) % 5);
            }
        }
 
        public String Value1NormalNextColor
        {
            get
            {
                return colorFromValue((Value1 + 1) % 5);
            }
        }
        public String Value2NormalNextColor
        {
            get
            {
                return colorFromValue((Value2 + 1) % 5);
            }
        }
        public String Value3NormalNextColor
        {
            get
            {
                return colorFromValue((Value3 + 1) % 5);
            }
        }
        public String Value4NormalNextColor
        {
            get
            {
                return colorFromValue((Value4 + 1) % 5);
            }
        }
        public String Value5NormalNextColor
        {
            get
            {
                return colorFromValue((Value5 + 1) % 5);
            }
        }
        //Next & Prev colors for HARD level
        public String Value1HardPrevColor
        {
            get
            {
                return colorFromValue((Value1 + 6) % 7);
            }
        }
        public String Value2HardPrevColor
        {
            get
            {
                return colorFromValue((Value2 + 6) % 7);
            }
        }
        public String Value3HardPrevColor
        {
            get
            {
                return colorFromValue((Value3 + 6) % 7);
            }
        }
        public String Value4HardPrevColor
        {
            get
            {
                return colorFromValue((Value4 + 6) % 7);
            }
        }
        public String Value5HardPrevColor
        {
            get
            {
                return colorFromValue((Value5 + 6) % 7);
            }
        }

        public String Value1HardNextColor
        {
            get
            {
                return colorFromValue((Value1 + 1) % 7);
            }
        }
        public String Value2HardNextColor
        {
            get
            {
                return colorFromValue((Value2 + 1) % 7);
            }
        }
        public String Value3HardNextColor
        {
            get
            {
                return colorFromValue((Value3 + 1) % 7);
            }
        }
        public String Value4HardNextColor
        {
            get
            {
                return colorFromValue((Value4 + 1) % 7);
            }
        }
        public String Value5HardNextColor
        {
            get
            {
                return colorFromValue((Value5 + 1) % 7);
            }
        }

        //--- --- ---
        public String colorFromValue(int Value)
        {
            if (Value == 0) return "Black";
            else if (Value == 1) return "Red";
            else if (Value == 2) return "Blue";
            else if (Value == 3) return "White";
            else if (Value == 4) return "Green";
            else if (Value == 5) return "Orange";
            else if (Value == 6) return "Brown";
            else if (Value == 7) return "Pink";
            else return "Gray";
        }

        public Move checkMarks(Move Data, int size)
        {
            //sprawdzanie rozwiązania
            int blackPoints = 0;
            int whitePoints = 0;

            int[] flagsM = { 0, 0, 0, 0, 0, 0, 0 };
            int[] flagsD = { 0, 0, 0, 0, 0, 0, 0 };
            int[] data = { Data.Value1, Data.Value2, Data.Value3, Data.Value4, Data.Value5 };
            int[] move = { this.Value1, this.Value2, this.Value3, this.Value4, this.Value5 };

            for (int i = 0; i < size; i++)
            {
                if (data[i] == move[i])
                {
                    flagsM[i] = 1;
                    flagsD[i] = 1;
                    blackPoints++;
                }
            }

            for (int i = 0; i < size; i++)
            {
                if (flagsD[i] != 1)
                {
                    for (int k = 0; k < size; k++)
                    {
                        if (flagsM[k] != 1)
                        {
                            if (data[k] == move[i])
                            {
                                flagsM[k] = 1;
                                whitePoints++;
                                break;
                            }
                        }
                    }
                }
            }

            Move moveToReturn = new Move(this.Value1, this.Value2, this.Value3, this.Value4, this.Value5);
            moveToReturn.Black = blackPoints;
            moveToReturn.White = whitePoints;

            return moveToReturn;
        }

        public void clearMove()
        {
            this.Black = 0;
            this.White = 0;
            this.Value1 = 0;
            this.Value2 = 0;
            this.Value3 = 0;
            this.Value4 = 0;
            this.Value5 = 0;
        }

        public static Move randomData(int size, int numOfColors)
        {
            int[] newData = { 0, 0, 0, 0, 0, 0, 0 };
            int i;
            Random random = new Random();

            for (i = 0; i < size; i++)
            {
                newData[i] = random.Next(0, 100) % numOfColors;
            }

            Move data = new Move(newData[0], newData[1], newData[2], newData[3], newData[4]);

            return data;
        }

        public void copyMove(Move newMove)
        {
            this.value1 = newMove.value1;
            this.value2 = newMove.value2;
            this.value3 = newMove.value3;
            this.value4 = newMove.value4;
            this.value5 = newMove.value5;
            this.black = newMove.black;
            this.white = newMove.white;
        }
    }

    public class Moves : ObservableCollection<Move>
    {

        public Moves()
        {
            /* Add(new Move(1, 2, 3, 4, 5, 6, 7));
             Add(new Move(1, 2, 3, 4, 5, 6, 7));
             Add(new Move(1, 2, 3, 4, 5, 6, 7));
             Add(new Move(1, 2, 3, 4, 5, 6, 7));
             Add(new Move(0, 0, 1, 2, 3, 4, 5, 6, 7));
                         Add(new Move(0, 0, 1, 2, 3, 4, 5, 6, 7));
                         Add(new Move(0, 0, 1, 2, 3, 4, 5, 6, 7));
                         Add(new Move(0, 0, 1, 2, 3, 4, 5, 6, 7));*/
        }

    }

    [DataContract]
    public class MoveAnemic
    {
        [DataMember()]
        public int value1;
        [DataMember()]
        public int value2;
        [DataMember()]
        public int value3;
        [DataMember()]
        public int value4;
        [DataMember()]
        public int value5;
        [DataMember()]
        public int black;
        [DataMember()]
        public int white;

        public MoveAnemic()
        {
            this.value1 = 0;
            this.value2 = 0;
            this.value3 = 0;
            this.value4 = 0;
            this.value5 = 0;
            this.black = 0;
            this.white = 0;
        }

        public MoveAnemic(Move newMove)
        {
            this.value1 = newMove.Value1;
            this.value2 = newMove.Value2;
            this.value3 = newMove.Value3;
            this.value4 = newMove.Value4;
            this.value5 = newMove.Value5;
            this.black = newMove.Black;
            this.white = newMove.White;
        }

        public MoveAnemic(Move newMove, int add, int multi)
        {
            this.value1 = (newMove.Value1 + add) * multi;
            this.value2 = (newMove.Value2 + add) * multi;
            this.value3 = (newMove.Value3 + add) * multi;
            this.value4 = (newMove.Value4 + add) * multi;
            this.value5 = (newMove.Value5 + add) * multi;
            this.black = newMove.Black;
            this.white = newMove.White;
        }
    }

}
