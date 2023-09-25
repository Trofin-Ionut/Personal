namespace Crud_tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange => prepare variables,containers and whatever you need in order to use the method you want to test.
            ClassForTestingExample cfte = new();
            int input1 = 10, input2 = 50;
            int expectedValue = 60;

            //Act  (actually use the method and see what it does)
            int actualValue= cfte.Sum(input1, input2);

            //Assert (compare the value you got with the value you've expected)
            Assert.Equal(expectedValue, actualValue);

            //View -> Test Explorer
        }
    }
}