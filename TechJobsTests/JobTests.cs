using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechJobsOO;

namespace TechJobsTests
{
    [TestClass]
    public class JobTests
    {
        [TestMethod]
        public void TestSettingJobID()
        {
            Job job1 = new Job();
            Job job2 = new Job();
            Assert.IsFalse(job1.Id == job2.Id);
        }

        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            Job testJob = new Job("Product Tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality Control"), new CoreCompetency("Persistence"));
            Assert.IsTrue((testJob.Name == "Product Tester") && (testJob.EmployerName.Value == "ACME") && (testJob.EmployerLocation.Value == "Desert")
                && (testJob.JobType.Value == "Quality Control") && (testJob.JobCoreCompetency.Value == "Persistence"));
        }

        [TestMethod]
        public void TestJobsForEquality()
        {
            Job job1 = new Job("Product Tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality Control"), new CoreCompetency("Persistence"));
            Job job2 = new Job("Product Tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality Control"), new CoreCompetency("Persistence"));
            Assert.IsFalse(job1 == job2);
        }

        [TestMethod]
            public void TestJobsForBlankLines()
            {
                Job testJob = new Job("Product Tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality Control"), new CoreCompetency("Persistence"));
                Assert.AreEqual('\n', testJob.ToString()[0]);
                Assert.AreEqual('\n', testJob.ToString()[(testJob.ToString().Length)-1]);
        }

        [TestMethod]
        public void TestJobsForEmptyField()
        {
            Job testJob = new Job("Product Tester", new Employer(""), new Location("Desert"), new PositionType("Quality Control"), new CoreCompetency("Persistence"));
            string expected = "\n" +
            "ID: " + testJob.Id + "\n" +
            "Name: Product Tester\n" +
            "Employer: Data not available\n" + 
            "Location: Desert\n" +
            "Position Type: Quality Control\n" +
            "Core Competency: Persistence\n";
            Assert.AreEqual(expected, testJob.ToString());
        }

        [TestMethod]
        public void TestJobsForOnlyID()
        {
            Job testJob = new Job("", new Employer(""), new Location(""), new PositionType(""), new CoreCompetency(""));
            Assert.AreEqual("OOPS! This job does not seem to exist.", testJob.ToString());
        }
    }
}
