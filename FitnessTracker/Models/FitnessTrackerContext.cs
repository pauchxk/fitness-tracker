using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Models;

public partial class FitnessTrackerContext : DbContext
{
    public FitnessTrackerContext()
    {
    }

    public FitnessTrackerContext(DbContextOptions<FitnessTrackerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DailyFood> DailyFoods { get; set; }

    public virtual DbSet<DailyLog> DailyLogs { get; set; }

    public virtual DbSet<DailyWorkout> DailyWorkouts { get; set; }

    public virtual DbSet<Exercise> Exercises { get; set; }

    public virtual DbSet<ExercisesInWorkout> ExercisesInWorkouts { get; set; }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<FoodInMeal> FoodInMeals { get; set; }

    public virtual DbSet<Goal> Goals { get; set; }

    public virtual DbSet<Meal> Meals { get; set; }

    public virtual DbSet<PersonalRecord> PersonalRecords { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=fitness_tracker;TrustServerCertificate=True;User ID=sa;Password=Twojays37a!");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_CI_AS");

        modelBuilder.Entity<DailyFood>(entity =>
        {
            entity.HasKey(e => new { e.LogId, e.MealId }).HasName("Daily_Foods_PK");

            entity.ToTable("Daily_Foods");

            entity.Property(e => e.LogId).HasColumnName("Log_ID");
            entity.Property(e => e.MealId).HasColumnName("Meal_ID");
            entity.Property(e => e.Amount).HasColumnType("decimal(2, 0)");

            entity.HasOne(d => d.Log).WithMany(p => p.DailyFoods)
                .HasForeignKey(d => d.LogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Log_ID");

            entity.HasOne(d => d.Meal).WithMany(p => p.DailyFoods)
                .HasForeignKey(d => d.MealId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Meal_ID");
        });

        modelBuilder.Entity<DailyLog>(entity =>
        {
            entity.HasKey(e => e.LogId);

            entity.ToTable("Daily_Log");

            entity.Property(e => e.LogId).HasColumnName("Log_ID");
            entity.Property(e => e.CaffeineIntake).HasColumnName("Caffeine_Intake");
            entity.Property(e => e.LogDate).HasColumnName("Log_Date");
            entity.Property(e => e.SleepHours)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("Sleep_Hours");
            entity.Property(e => e.Weight).HasColumnType("decimal(5, 2)");
        });

        modelBuilder.Entity<DailyWorkout>(entity =>
        {
            entity.HasKey(e => e.DworkoutId).HasName("PK_Daily_Workout_1");

            entity.ToTable("Daily_Workout");

            entity.Property(e => e.DworkoutId)
                .ValueGeneratedNever()
                .HasColumnName("DWorkout_ID");
            entity.Property(e => e.LogId).HasColumnName("Log_ID");
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.PreWorkout).HasColumnName("Pre_Workout");

            entity.HasOne(d => d.Log).WithMany(p => p.DailyWorkouts)
                .HasForeignKey(d => d.LogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Daily_Workout_Daily_Log1");
        });

        modelBuilder.Entity<Exercise>(entity =>
        {
            entity.Property(e => e.ExerciseId).HasColumnName("Exercise_ID");
            entity.Property(e => e.ExerciseName)
                .HasMaxLength(50)
                .HasColumnName("Exercise_Name");
            entity.Property(e => e.ExerciseType)
                .HasMaxLength(50)
                .HasColumnName("Exercise_Type");
            entity.Property(e => e.Goal).HasMaxLength(50);
            entity.Property(e => e.MuscleGroup)
                .HasMaxLength(50)
                .HasColumnName("Muscle_Group");
            entity.Property(e => e.MuscleSubGroup)
                .HasMaxLength(50)
                .HasColumnName("Muscle_SubGroup");
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.ReccommendedRepsSets)
                .HasMaxLength(50)
                .HasColumnName("Reccommended_Reps_Sets");
        });

        modelBuilder.Entity<ExercisesInWorkout>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Exercises_in_Workout");

            entity.Property(e => e.DworkoutId).HasColumnName("DWorkout_ID");
            entity.Property(e => e.ExerciseId).HasColumnName("Exercise_ID");
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.Rpe).HasColumnName("RPE");
            entity.Property(e => e.Weight).HasColumnType("decimal(2, 0)");

            entity.HasOne(d => d.Dworkout).WithMany()
                .HasForeignKey(d => d.DworkoutId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DWorkout_ID");

            entity.HasOne(d => d.Exercise).WithMany()
                .HasForeignKey(d => d.ExerciseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Exercise_ID");
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.HasKey(e => e.FoodId).HasName("PK_Foods_1");

            entity.Property(e => e.FoodId).HasColumnName("Food_ID");
            entity.Property(e => e.FoodGroup)
                .HasMaxLength(50)
                .HasColumnName("Food_Group");
            entity.Property(e => e.FoodName)
                .HasMaxLength(50)
                .HasColumnName("Food_Name");
            entity.Property(e => e.FoodSubGroup)
                .HasMaxLength(50)
                .HasColumnName("Food_SubGroup");
            entity.Property(e => e.Notes).HasMaxLength(500);
        });

        modelBuilder.Entity<FoodInMeal>(entity =>
        {
            entity.HasKey(e => new { e.MealId, e.FoodId }).HasName("Food_in_Meal_PK");

            entity.ToTable("Food_in_Meal");

            entity.Property(e => e.MealId).HasColumnName("Meal_ID");
            entity.Property(e => e.FoodId).HasColumnName("Food_ID");

            entity.HasOne(d => d.Food).WithMany(p => p.FoodInMeals)
                .HasForeignKey(d => d.FoodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Food_ID2");

            entity.HasOne(d => d.Meal).WithMany(p => p.FoodInMeals)
                .HasForeignKey(d => d.MealId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Meal_ID2");
        });

        modelBuilder.Entity<Goal>(entity =>
        {
            entity.Property(e => e.GoalId).HasColumnName("Goal_ID");
            entity.Property(e => e.GoalType)
                .HasMaxLength(50)
                .HasColumnName("Goal_Type");
            entity.Property(e => e.MuscleGroup)
                .HasMaxLength(50)
                .HasColumnName("Muscle_Group");
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.Period).HasMaxLength(20);
            entity.Property(e => e.TargetValue)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Target_Value");
            entity.Property(e => e.Unit).HasMaxLength(20);
        });

        modelBuilder.Entity<Meal>(entity =>
        {
            entity.Property(e => e.MealId).HasColumnName("Meal_ID");
            entity.Property(e => e.MealName)
                .HasMaxLength(50)
                .HasColumnName("Meal_Name");
            entity.Property(e => e.Method).HasMaxLength(500);
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<PersonalRecord>(entity =>
        {
            entity.ToTable("Personal_Records");

            entity.Property(e => e.PersonalRecordId).HasColumnName("Personal_Record_ID");
            entity.Property(e => e.ExerciseId).HasColumnName("Exercise_ID");
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.Weight).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Exercise).WithMany(p => p.PersonalRecords)
                .HasForeignKey(d => d.ExerciseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Personal_Records_Exercises");
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("User_Profile");

            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.Height).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("User_Name");
            entity.Property(e => e.Weight).HasColumnType("decimal(5, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
