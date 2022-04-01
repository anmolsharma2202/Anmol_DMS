using Microsoft.EntityFrameworkCore;


namespace DMSWebAPI.Models
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions options): base(options)
        {

        }
        public DbSet<Login> login { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<UsageCondition> UsageConditions { get; set; }
        public DbSet<ReactionAgent> ReactionAgents { get; set; }
        public DbSet<AllergicSymptom> AllergicSymptoms { get; set; }
        public DbSet<AntiAllergicDrug> AntiAllergicDrugs { get; set; }
        public DbSet<AntiAllergicDrugSymptom> AntiAllergicDrugSymptoms { get; set; }
        public DbSet<ConditionDetail> ConditionDetails { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<NewDrugTrial> NewDrugTrials { get; set; }
    }
}
