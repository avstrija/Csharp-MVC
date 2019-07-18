using System;
using System.Collections.Generic;
using System.Linq;

namespace TemplateClass
{
    public class TemplateEngine
    {
        string template;

        public void StoreTemplate(string userTemplate) 
        {
            template = userTemplate;
        }

        public string GetTemplate() 
        {
            return template;
        }

        public string[] FindVariables() 
        {
            var parts = template.Split(new char[] { '[', ']' }).ToList();

            var variables = new List<string>();
            for(int i = 0; i < parts.Count; i++) 
            {
                if (i % 2 == 1) {
                    variables.Add(parts[i]);
                }
            }
            return variables.ToArray();
        }
    }
}
