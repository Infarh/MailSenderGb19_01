﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleTest
{
    static class FileInfoExtensions
    {
        public static IEnumerable<string> GetLines(this FileInfo file)
        {
            if(file is null) throw new ArgumentNullException(nameof(file));
            if (!file.Exists) throw new FileNotFoundException("Файл не найден", file.FullName);

            using (var reader = file.OpenText())
                while (!reader.EndOfStream)
                    yield return reader.ReadLine();
        }
    }
}
