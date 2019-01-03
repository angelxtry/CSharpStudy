using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;

namespace JsonStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            var novels = new Novel[]
            {
                new Novel
                {
                    Author = "아이작 아시모프",
                    Title = "로봇",
                    Published = 1950,
                },
                new Novel
                {
                    Author = "조지 오웰",
                    Title = "1984",
                    Published = 1949,
                },
            };

            // 직렬화 - 객체를 Json File로
            //SerializeJson(novels);

            /*
             * JSON 데이터를 문자열 형태로 만들기 위해
             * MemoryStream에 JSON 데이터를 출력한 후 ToArray() 메서드로 문자 배열로 변환
             * Encoding 클래스에 있는 GetString 메서드를 통해 문자열로 변환
             */
            //Console.WriteLine(TransJsonToString(novels));

            // 역직렬화 - json 파일을 읽어서 처리
            //var novelsFromJsonFile = ReadJsonFile();
            //foreach (var novel in novelsFromJsonFile)
            //{
            //    Console.WriteLine(novel);
            //}

            // 역직렬화 - json string 데이터를 객체로
            var novelsFromJsonString = DeserializeJson(TransJsonToString(novels));
            foreach (var novel in novelsFromJsonString)
            {
                Console.WriteLine(novel);
            }

            var abbreviationDict = new AbbreviationDict
            {
                Abbreviations = new Dictionary<string, string>
                {
                    {"ODA", "정부개발원조"},
                    {"OECD", "경제 협력 개발 기구"},
                    {"OPEC", "석유 수출국 기구"},
                }
            };

            // .NET Framework 4.5 이상
            //var settings = new DataContractJsonSerializerSettings
            //{
            //    UseSimpleDictionaryFormat = true,
            //};
            Console.ReadLine();
        }

        private static void SerializeJson(Novel[] novels)
        {
            using (var stream = new FileStream("novels.json", FileMode.Create, FileAccess.Write))
            {
                var serializer = new DataContractJsonSerializer(novels.GetType());
                serializer.WriteObject(stream, novels);
            }
        }

        private static string TransJsonToString(Novel[] novels)
        {
            /*
             * JSON 데이터를 문자열 형태로 만들기 위해
             * MemoryStream에 JSON 데이터를 출력한 후 ToArray() 메서드로 문자 배열로 변환
             * Encoding 클래스에 있는 GetString 메서드를 통해 문자열로 변환
             */
            string jsonText = "";
            using (var stream = new MemoryStream())
            {
                var serializer = new DataContractJsonSerializer(novels.GetType());
                serializer.WriteObject(stream, novels);
                stream.Close();
                jsonText = Encoding.UTF8.GetString(stream.ToArray());
            }
            return jsonText;
        }

        private static Novel[] ReadJsonFile()
        {
            using (var stream = new FileStream("novels.json", FileMode.Open, FileAccess.Read))
            {
                var serializer = new DataContractJsonSerializer(typeof(Novel[]));
                var novels = serializer.ReadObject(stream) as Novel[];
                return novels;
            }
        }

        private static Novel[] DeserializeJson(string jsonString)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(jsonString);
            using (var stream = new MemoryStream(byteArray))
            {
                var serializer = new DataContractJsonSerializer(typeof(Novel[]));
                var novels = serializer.ReadObject(stream) as Novel[];
                return novels;
            }
        }
    }
}
