using Microsoft.VisualStudio.TestTools.UnitTesting;
using TemplateClass;

namespace TemplateEngine
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void template_engine_exists()
        {
            TemplateEngine template = new TemplateEngine();
        }

        [TestMethod]
        public void can_take_a_template_and_return_it() 
        {
            string template = "I like [plural noun]!";
            TemplateEngine engine = new TemplateEngine();
            engine.CreateTemplate(template);
            Assert.AreEqual(template, engine.GetTemplate()); 
        }

        public void Can_Find_Zero_Variables()
        {
            TemplateEngine te = new TemplateEngine();
            te.StoreTemplate("This is my template.");
            string[] empty = new string[0];
            Assert.AreEqual(empty, te.FindVariables());
        }
    }
}
