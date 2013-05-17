using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Windows.Storage;
using Windows.Storage.Streams;

namespace AppTests
{
    class StorageProxy
    {
        //ZAPIS DO PLIKU Listy
        public static async Task writeToFile(String filename, Moves movesToSave)
        {
            String data = "";
            List<MoveAnemic> moves = new List<MoveAnemic>();
            foreach (Move m in movesToSave)
            {
                moves.Add(new MoveAnemic(m));
            }
            //serializacja
            using (MemoryStream stream = new MemoryStream())
            {
                var serializer = new XmlSerializer(moves.GetType());
                serializer.Serialize(stream, moves);
                stream.Seek(0, SeekOrigin.Begin);
                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream))
                {
                    data = reader.ReadToEnd();

                    stream.Seek(0, SeekOrigin.Begin);
                    stream.Position = 0;

                }
            }
            //zapis do pliku
            using(Stream s = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(filename, CreationCollisionOption.ReplaceExisting)){
                using(StreamWriter sw = new StreamWriter(s)){
                    await sw.WriteAsync(data);
                }
            }
        }
        //ZAPIS DO PLIKU Ruchu
        public static async Task writeToFile(String filename, Move moveToSave)
        {
            String data = "";
            MoveAnemic move = new MoveAnemic(moveToSave, 4, 8);

            //serializacja
            using (MemoryStream stream = new MemoryStream())
            {
                var serializer = new XmlSerializer(move.GetType());
                serializer.Serialize(stream, move);
                stream.Seek(0, SeekOrigin.Begin);
                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream))
                {
                    data = reader.ReadToEnd();

                    stream.Seek(0, SeekOrigin.Begin);
                    stream.Position = 0;

                }
            }
            //zapis do pliku
            using (Stream s = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(filename, CreationCollisionOption.ReplaceExisting))
            {
                using (StreamWriter sw = new StreamWriter(s))
                {
                    await sw.WriteAsync(data);
                }
            }

        }

        //ODCZYT Z PLIKU Listy
        public static async Task readFromFile(String filename, Moves data)
        {
            List<MoveAnemic> moves = new List<MoveAnemic>();

            //odczyt z pliku
            try
            {
                using (Stream s = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(filename))
                {
                    using (StreamReader sr = new StreamReader(s))
                    {
                        // serialInfo.Text = sr.ReadToEnd();
                        s.Seek(0, SeekOrigin.Begin);
                        s.Position = 0;
                        //deserializacja
                        var serializer = new XmlSerializer(moves.GetType());
                        moves = serializer.Deserialize(s) as List<MoveAnemic>;
                        Moves newMoveList = new Moves();
                        foreach (MoveAnemic m in moves)
                        {
                            data.Add(new Move(m));
                        }
                        
                    }
                }
            }
            catch (FileNotFoundException e) { }
        }
        //ODCZYT Z PLIKU Ruchu
        public static async void readFromFile(String filename, Move data)
        {
            MoveAnemic move = new MoveAnemic();

            //odczyt z pliku
            try
            {
                using (Stream s = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(filename))
                {
                    using (StreamReader sr = new StreamReader(s))
                    {
                        // serialInfo.Text = sr.ReadToEnd();
                        s.Seek(0, SeekOrigin.Begin);
                        s.Position = 0;
                        //deserializacja
                        var serializer = new XmlSerializer(move.GetType());
                        move = serializer.Deserialize(s) as MoveAnemic;

                        data.copyMove(new Move(move, 4, 8));
                    }
                }
            }
            catch (FileNotFoundException e) { }
        }

        //ZAPIS DO PLIKU LISTY Wyników
        public static async Task writeToFile(String filename, ScoresList scoresToSave)
        {
            String data = "";
            List<ScoreAnemic> scores = new List<ScoreAnemic>();
            foreach (Score s in scoresToSave)
            {
                scores.Add(new ScoreAnemic(s));
            }
            //serializacja
            using (MemoryStream stream = new MemoryStream())
            {
                var serializer = new XmlSerializer(scores.GetType());
                serializer.Serialize(stream, scores);
                stream.Seek(0, SeekOrigin.Begin);
                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream))
                {
                    data = reader.ReadToEnd();

                    stream.Seek(0, SeekOrigin.Begin);
                    stream.Position = 0;

                }
            }
            //zapis do pliku
            using (Stream s = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(filename, CreationCollisionOption.ReplaceExisting))
            {
                using (StreamWriter sw = new StreamWriter(s))
                {
                    await sw.WriteAsync(data);
                }
            }
        }
        //ODCZYT Z PLIKU LISTY Wyników
        public static async Task readFromFile(String filename, ScoresList data)
        {
            List<ScoreAnemic> scores = new List<ScoreAnemic>();

            //odczyt z pliku
            try
            {
                using (Stream s = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(filename))
                {
                    using (StreamReader sr = new StreamReader(s))
                    {
                        // serialInfo.Text = sr.ReadToEnd();
                        s.Seek(0, SeekOrigin.Begin);
                        s.Position = 0;
                        //deserializacja
                        var serializer = new XmlSerializer(scores.GetType());
                        scores = serializer.Deserialize(s) as List<ScoreAnemic>;
                        Moves newMoveList = new Moves();
                        foreach (ScoreAnemic m in scores)
                        {
                            data.Add(new Score(m));
                        }

                    }
                }
            }
            catch (FileNotFoundException e) { }
        }

    }
}
