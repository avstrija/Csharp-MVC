using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Buzzfeed
{

    class MainClass
    {
        public static int PickAnswer(Dictionary<int, int> answers, int score)
            {
            Console.Write("Pick an answer (enter number): ");
            string ans = Console.ReadLine();
            int answer = Convert.ToInt16(ans);
            if (answers.ContainsKey(answer)) {score += answers[answer];}
            else { PickAnswer(answers, score); }
            return score;
}

        public static void PrintAll(SqlConnection connection)
        {
            SqlCommand print = new SqlCommand("SELECT * FROM Quizzes;", connection);
            SqlDataReader reader = print.ExecuteReader();
            Console.WriteLine("These are your quizzes!");

            while (reader.Read())
            {
                Console.WriteLine(reader["Id"] + " " + reader["Title"]);
                Console.WriteLine("<<<" + reader["Description"] + ">>>");
            }
            Console.WriteLine();
            reader.Close();
        }

        public static void PrintQuestions(SqlConnection connection, int ID)
        {
            SqlCommand commandShow = new SqlCommand($"Select Qz.id AS ID, Qu.quizid AS QuizID, Qu.Text AS QuestionText, An.Text AS AnswerText, Qu.QuestionNumber AS QuestionNumber from [Buzzfeed-Session8].dbo.Quizzes as Qz JOIN [Buzzfeed-Session8].dbo.Questions as Qu on Qz.ID = Qu.QuizID JOIN [Buzzfeed-Session8].dbo.Answers as An on Qu.ID = An.QuestionId WHERE Qz.ID={ID} ORDER by Qu.QuestionNumber", connection);
            SqlDataReader reader = commandShow.ExecuteReader();
            string prev_question = "";
            int i = 0;
            while (reader.Read())
            {
                string curr_question = Convert.ToString(reader["QuestionText"]);
                if (curr_question != prev_question)
                {
                    i = 1;
                    Console.WriteLine(reader["QuestionNumber"] + ". " + reader["QuestionText"]);
                }
                Console.WriteLine("    " + i + ") " + reader["AnswerText"]);
                ++i;
                prev_question = curr_question;

            }
            reader.Close();
        }

        public static void TakeQuiz(SqlConnection connection, int ID)
        {
            SqlCommand commandShow = new SqlCommand($"Select Qz.id AS Id, Qu.quizid AS QuizID, Qu.Text AS QuestionText, An.AnswerNumber AS AnswerNumber, An.Text AS AnswerText, An.Score AS Score, Qu.QuestionNumber AS QuestionNumber from [Buzzfeed-Session8].dbo.Quizzes as Qz JOIN [Buzzfeed-Session8].dbo.Questions as Qu on Qz.ID = Qu.QuizID JOIN [Buzzfeed-Session8].dbo.Answers as An on Qu.ID = An.QuestionId WHERE Qz.ID={ID} ORDER by Qu.QuestionNumber", connection);

            SqlDataReader reader = commandShow.ExecuteReader();
            string prev_question = "";
            int i = 0;
            Dictionary<int, int> answers = new Dictionary<int,int>();
            int score = 0;
            while (reader.Read())
            {
                string curr_question = Convert.ToString(reader["QuestionText"]);
                if (curr_question != prev_question)
                {
                    if(i!=0) {
                        score = PickAnswer(answers, score);
                        answers.Clear();
                    }

                    i = 1;
                    Console.WriteLine(reader["QuestionNumber"] + ". " + reader["QuestionText"]);
                }
                Console.WriteLine("    " + i + ") " + reader["AnswerText"]);
                answers[i] = Convert.ToInt16(reader["Score"]);
                ++i;
                prev_question = curr_question;

            }
            reader.Close();
            score = PickAnswer(answers, score);
            int resID = ShowResult(connection, ID, score);

            SqlCommand addResult = new SqlCommand($"INSERT INTO [Buzzfeed-Session8].dbo.History (ResultId) VALUES ('{resID}'); SELECT @@Identity AS ID", connection);
            SqlDataReader readerQuery = addResult.ExecuteReader();
            while (readerQuery.Read())
            {
                Console.WriteLine("Your result is recorded under number " + readerQuery["ID"]);
            }
            readerQuery.Close();
        }

        public static int ShowResult(SqlConnection connection, int ID,int score) {
            SqlCommand result = new SqlCommand($"Select * from [Buzzfeed-Session8].dbo.Results WHERE QuizId ={ID} AND ScoreMin <= {score} AND ScoreMax >= {score};", connection);
            SqlDataReader reader = result.ExecuteReader();
            int resID = 0;
            while (reader.Read()) 
            {
                Console.WriteLine(reader["Title"]);
                Console.WriteLine(reader["Description"]);
                resID = Convert.ToInt16(reader["Id"]);
            }
            reader.Close();
            return resID;
        }

        public static void ShareResult(SqlConnection connection, int hisID)
        {
            SqlCommand result = new SqlCommand($"Select * from [Buzzfeed-Session8].dbo.Results JOIN [Buzzfeed-Session8].dbo.History ON [Buzzfeed-Session8].dbo.History.ResultId = [Buzzfeed-Session8].dbo.Results.Id WHERE HistoryId ={hisID};", connection);
            SqlDataReader reader = result.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["Title"]);
                Console.WriteLine(reader["Description"]);
            }
            reader.Close();
        }

        public static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(@"
Server=192.168.1.65; Database=Buzzfeed-Session8; User Id=academy_admin; Password=12345;");
            connection.Open();
            bool keepGoing = true;

            while(keepGoing)
            {
                Console.WriteLine("What do you want to do? P - see all quizzes\n" +
                "Q — see questions for a quiz, T — take a quiz,\n" +
                " S — share results, E — exit");
                string choice = Console.ReadLine();
                if (choice.ToLower() == "p") { PrintAll(connection); }
                else if (choice.ToLower() == "q")
                {
                    Console.WriteLine("Enter the quiz number.\n" +
                        "If you want to see all the questions first, press P");
                    choice = Console.ReadLine();
                    if (choice.ToLower() == "p") { PrintAll(connection); }
                    else
                    {
                        int result;
                        bool num = int.TryParse(choice, out result);
                        if (num)
                        {
                            int ID = Convert.ToInt16(choice);
                            Console.WriteLine(ID);
                            PrintQuestions(connection, ID);
                        }


                    }
                }
                else if (choice.ToLower() == "t")
                {

                    Console.WriteLine("Enter the quiz number.\n" +
                        "If you want to see all the questions first, press P");
                    choice = Console.ReadLine();
                    if (choice.ToLower() == "p") { PrintAll(connection); }
                    else
                    {
                        int result;
                        bool num = int.TryParse(choice, out result);
                        if (num)
                        {
                            int ID = Convert.ToInt16(choice);
                            TakeQuiz(connection, ID);
                        }
                    }
                }
                else if (choice.ToLower() == "s") 
                {
                    Console.WriteLine("What's the result ID?");
                    string new_res = Console.ReadLine();
                    int result;
                    bool num = int.TryParse(new_res, out result);
                    if (num)
                    {
                        int hisID = Convert.ToInt16(new_res);
                        ShareResult(connection, hisID);
                    }
                     
                }
                else if (choice.ToLower() == "e") { keepGoing = false; }
                else { Console.WriteLine("Unknown command. Try again"); }
            }
            connection.Close();
        }
    }
}
