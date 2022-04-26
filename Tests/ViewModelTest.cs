using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewModel;

namespace Tests
{
    [TestClass]
    public class ViewModelTest
    {
        MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();

        [TestMethod]
        public void valuesViewModelTest()
        {
            Assert.AreEqual(400, mainWindowViewModel.Height);
            Assert.AreEqual(700, mainWindowViewModel.Width);
        }
    }
}
