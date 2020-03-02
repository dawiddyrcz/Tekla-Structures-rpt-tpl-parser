using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace Tekla.Structures.RPT.Tests
{
    public class ParserTests
    {
        private string GetTestDir()
        {
            return Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory));
        }

        [Test]
        public void Test01()
        {
            var fileName = Path.Combine(GetTestDir(), "LM.rpt");
            var text = File.ReadAllText(fileName);

            var parser = new Parser();

            var result = parser.Parse(text);

            //Create breakpoint here and check structure of result
            int a = 0;
        }

        //TODO some files have different type
        List<string> ignoreFiles = new List<string>()
        {
            "6_PDMS_end_code_list.rpt",
            "Castunit_rebarlist.tpl",
            "current_phase.tpl",
        };

        [Test]
        public void GetAllFilesToCheckEnums()
        {
            var parser = new Parser();
            string directory = @"E:\Program Files\Tekla Structures\2019.1\Environments";

            var files = GetFilesRec(directory);

            foreach (var file in files)
            {
                var name = new FileInfo(file).Name;
                if (ignoreFiles.Contains(name))
                    continue;

                try
                {
                    var text = File.ReadAllText(file);

                    if (text.Contains("object Text"))
                        continue;

                    var result = parser.Parse(text);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //throw;
                }
            }
        }

        public List<string> GetFilesRec(string dir)
        {
            var output = new List<string>();
            output.AddRange(Directory.GetFiles(dir, "*.rpt"));
            output.AddRange(Directory.GetFiles(dir, "*.tpl"));

            foreach (var subDir in Directory.GetDirectories(dir))
            {
                output.AddRange(GetFilesRec(subDir));
            }

            return output;
        }
    }
}
