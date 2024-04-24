﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by Reqnroll (https://www.reqnroll.net/).
//      Reqnroll Version:1.0.0.0
//      Reqnroll Generator Version:1.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace UI.Tests.ReqnrollProject.Features
{
    using Reqnroll;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "1.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class LogInTestsFeature
    {
        
        private static Reqnroll.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "LogInTests.feature"
#line hidden
        
        public virtual Microsoft.VisualStudio.TestTools.UnitTesting.TestContext TestContext
        {
            get
            {
                return this._testContext;
            }
            set
            {
                this._testContext = value;
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static async System.Threading.Tasks.Task FeatureSetupAsync(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = Reqnroll.TestRunnerManager.GetTestRunnerForAssembly(null, System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
            Reqnroll.FeatureInfo featureInfo = new Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "LogInTests", null, ProgrammingLanguage.CSharp, featureTags);
            await testRunner.OnFeatureStartAsync(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static async System.Threading.Tasks.Task FeatureTearDownAsync()
        {
            await testRunner.OnFeatureEndAsync();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public async System.Threading.Tasks.Task TestInitializeAsync()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "LogInTests")))
            {
                await global::UI.Tests.ReqnrollProject.Features.LogInTestsFeature.FeatureSetupAsync(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public async System.Threading.Tasks.Task TestTearDownAsync()
        {
            await testRunner.OnScenarioEndAsync();
        }
        
        public void ScenarioInitialize(Reqnroll.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Microsoft.VisualStudio.TestTools.UnitTesting.TestContext>(_testContext);
        }
        
        public async System.Threading.Tasks.Task ScenarioStartAsync()
        {
            await testRunner.OnScenarioStartAsync();
        }
        
        public async System.Threading.Tasks.Task ScenarioCleanupAsync()
        {
            await testRunner.CollectScenarioErrorsAsync();
        }
        
        public virtual async System.Threading.Tasks.Task FeatureBackgroundAsync()
        {
#line 3
#line hidden
#line 4
await testRunner.GivenAsync("Open Log In Page", ((string)(null)), ((Reqnroll.Table)(null)), "Given ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("LogInButtonTest")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "LogInTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mytag")]
        public async System.Threading.Tasks.Task LogInButtonTest()
        {
            string[] tagsOfScenario = new string[] {
                    "mytag"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            Reqnroll.ScenarioInfo scenarioInfo = new Reqnroll.ScenarioInfo("LogInButtonTest", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 7
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 3
await this.FeatureBackgroundAsync();
#line hidden
#line 8
 await testRunner.ThenAsync("Is Log In Button Displayed", ((string)(null)), ((Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("LogInTestSuperadmin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "LogInTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mytag")]
        public async System.Threading.Tasks.Task LogInTestSuperadmin()
        {
            string[] tagsOfScenario = new string[] {
                    "mytag"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            Reqnroll.ScenarioInfo scenarioInfo = new Reqnroll.ScenarioInfo("LogInTestSuperadmin", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 11
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 3
await this.FeatureBackgroundAsync();
#line hidden
#line 12
 await testRunner.WhenAsync("Log In Superadmin", ((string)(null)), ((Reqnroll.Table)(null)), "When ");
#line hidden
#line 13
 await testRunner.ThenAsync("Is Launches Button Displayed", ((string)(null)), ((Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("LogInTestDefaultUser")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "LogInTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mytag")]
        public async System.Threading.Tasks.Task LogInTestDefaultUser()
        {
            string[] tagsOfScenario = new string[] {
                    "mytag"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            Reqnroll.ScenarioInfo scenarioInfo = new Reqnroll.ScenarioInfo("LogInTestDefaultUser", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 16
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 3
await this.FeatureBackgroundAsync();
#line hidden
#line 17
 await testRunner.WhenAsync("Log In DefaultUser", ((string)(null)), ((Reqnroll.Table)(null)), "When ");
#line hidden
#line 18
 await testRunner.ThenAsync("Is Launches Button Displayed", ((string)(null)), ((Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        public virtual async System.Threading.Tasks.Task FilterByLaunchName(string launchName, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "mytag"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("launchName", launchName);
            Reqnroll.ScenarioInfo scenarioInfo = new Reqnroll.ScenarioInfo("FilterByLaunchName", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 21
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 3
await this.FeatureBackgroundAsync();
#line hidden
#line 22
 await testRunner.WhenAsync("Log In Superadmin", ((string)(null)), ((Reqnroll.Table)(null)), "When ");
#line hidden
#line 23
 await testRunner.AndAsync("CLick On Launches Button", ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 24
 await testRunner.AndAsync("Click On Filter By Button", ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 25
 await testRunner.AndAsync(string.Format("Enter Launch Name \'{0}\'", launchName), ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 26
 await testRunner.ThenAsync(string.Format("Check Launch Names \'{0}\' contains", launchName), ((string)(null)), ((Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("FilterByLaunchName: Variant 0")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "LogInTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mytag")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Variant 0")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:launchName", "Demo Api Tests")]
        public async System.Threading.Tasks.Task FilterByLaunchName_Variant0()
        {
#line 21
await this.FilterByLaunchName("Demo Api Tests", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("FilterByLaunchName: Variant 1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "LogInTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mytag")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Variant 1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:launchName", "Demo Api")]
        public async System.Threading.Tasks.Task FilterByLaunchName_Variant1()
        {
#line 21
await this.FilterByLaunchName("Demo Api", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("FilterByLaunchName: Variant 2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "LogInTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mytag")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Variant 2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:launchName", "Api Tests")]
        public async System.Threading.Tasks.Task FilterByLaunchName_Variant2()
        {
#line 21
await this.FilterByLaunchName("Api Tests", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("FilterByLaunchName: Variant 3")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "LogInTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mytag")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Variant 3")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:launchName", "Api Tests")]
        public async System.Threading.Tasks.Task FilterByLaunchName_Variant3()
        {
#line 21
await this.FilterByLaunchName("Api Tests", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("FilterByLaunchName: Variant 4")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "LogInTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mytag")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Variant 4")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:launchName", "Tests")]
        public async System.Threading.Tasks.Task FilterByLaunchName_Variant4()
        {
#line 21
await this.FilterByLaunchName("Tests", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("FilterByLaunchName: Variant 5")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "LogInTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mytag")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Variant 5")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:launchName", "Demo")]
        public async System.Threading.Tasks.Task FilterByLaunchName_Variant5()
        {
#line 21
await this.FilterByLaunchName("Demo", ((string[])(null)));
#line hidden
        }
        
        public virtual async System.Threading.Tasks.Task FilterByTotal(string total, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "mytag"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("total", total);
            Reqnroll.ScenarioInfo scenarioInfo = new Reqnroll.ScenarioInfo("FilterByTotal", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 39
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 3
await this.FeatureBackgroundAsync();
#line hidden
#line 40
 await testRunner.WhenAsync("Log In Superadmin", ((string)(null)), ((Reqnroll.Table)(null)), "When ");
#line hidden
#line 41
 await testRunner.AndAsync("CLick On Launches Button", ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 42
 await testRunner.AndAsync("Click On Filter By Button", ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 43
 await testRunner.AndAsync("Choose Filter By Total", ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 44
 await testRunner.AndAsync("Select Equal", ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 45
 await testRunner.AndAsync(string.Format("Enter Second Filter Field \'Total\' \'{0}\'", total), ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 46
 await testRunner.ThenAsync(string.Format("Check Total Values \'{0}\' contains", total), ((string)(null)), ((Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("FilterByTotal: 10")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "LogInTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mytag")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "10")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:total", "10")]
        public async System.Threading.Tasks.Task FilterByTotal_10()
        {
#line 39
await this.FilterByTotal("10", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("FilterByTotal: 15")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "LogInTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mytag")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "15")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:total", "15")]
        public async System.Threading.Tasks.Task FilterByTotal_15()
        {
#line 39
await this.FilterByTotal("15", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("FilterByTotal: 20")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "LogInTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mytag")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "20")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:total", "20")]
        public async System.Threading.Tasks.Task FilterByTotal_20()
        {
#line 39
await this.FilterByTotal("20", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("FilterByTotal: 25")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "LogInTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mytag")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "25")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:total", "25")]
        public async System.Threading.Tasks.Task FilterByTotal_25()
        {
#line 39
await this.FilterByTotal("25", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("FilterByTotal: 30")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "LogInTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mytag")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "30")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:total", "30")]
        public async System.Threading.Tasks.Task FilterByTotal_30()
        {
#line 39
await this.FilterByTotal("30", ((string[])(null)));
#line hidden
        }
        
        public virtual async System.Threading.Tasks.Task FilterByPassed(string passed, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "mytag"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("passed", passed);
            Reqnroll.ScenarioInfo scenarioInfo = new Reqnroll.ScenarioInfo("FilterByPassed", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 58
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 3
await this.FeatureBackgroundAsync();
#line hidden
#line 59
 await testRunner.WhenAsync("Log In Superadmin", ((string)(null)), ((Reqnroll.Table)(null)), "When ");
#line hidden
#line 60
 await testRunner.AndAsync("CLick On Launches Button", ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 61
 await testRunner.AndAsync("Click On Filter By Button", ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 62
 await testRunner.AndAsync("Choose Filter By Passed", ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 63
 await testRunner.AndAsync("Select Equal", ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 64
 await testRunner.AndAsync(string.Format("Enter Second Filter Field \'Passed\' \'{0}\'", passed), ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 65
 await testRunner.ThenAsync(string.Format("Check Passed Values \'{0}\' contains", passed), ((string)(null)), ((Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("FilterByPassed: 10")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "LogInTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mytag")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "10")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:passed", "10")]
        public async System.Threading.Tasks.Task FilterByPassed_10()
        {
#line 58
await this.FilterByPassed("10", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("FilterByPassed: 5")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "LogInTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mytag")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "5")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:passed", "5")]
        public async System.Threading.Tasks.Task FilterByPassed_5()
        {
#line 58
await this.FilterByPassed("5", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("FilterByPassed: 20")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "LogInTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mytag")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "20")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:passed", "20")]
        public async System.Threading.Tasks.Task FilterByPassed_20()
        {
#line 58
await this.FilterByPassed("20", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("FilterByPassed: 1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "LogInTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mytag")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:passed", "1")]
        public async System.Threading.Tasks.Task FilterByPassed_1()
        {
#line 58
await this.FilterByPassed("1", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("FilterByPassed: 30")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "LogInTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mytag")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "30")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:passed", "30")]
        public async System.Threading.Tasks.Task FilterByPassed_30()
        {
#line 58
await this.FilterByPassed("30", ((string[])(null)));
#line hidden
        }
        
        public virtual async System.Threading.Tasks.Task FilterByLaunchNameAndTotal(string launchName, string total, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "mytag"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("launchName", launchName);
            argumentsOfScenario.Add("total", total);
            Reqnroll.ScenarioInfo scenarioInfo = new Reqnroll.ScenarioInfo("FilterByLaunchNameAndTotal", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 76
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 3
await this.FeatureBackgroundAsync();
#line hidden
#line 77
 await testRunner.WhenAsync("Log In Superadmin", ((string)(null)), ((Reqnroll.Table)(null)), "When ");
#line hidden
#line 78
 await testRunner.AndAsync("CLick On Launches Button", ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 79
 await testRunner.AndAsync("Click On Filter By Button", ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 80
 await testRunner.AndAsync(string.Format("Enter Launch Name \'{0}\'", launchName), ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 81
 await testRunner.AndAsync("Click On Filter By Button", ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 82
 await testRunner.AndAsync("Choose Filter By Total", ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 83
 await testRunner.AndAsync("Select Equal", ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 84
 await testRunner.AndAsync(string.Format("Enter Second Filter Field \'Total\' \'{0}\'", total), ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 85
 await testRunner.ThenAsync(string.Format("Check Launch Names \'{0}\' contains", launchName), ((string)(null)), ((Reqnroll.Table)(null)), "Then ");
#line hidden
#line 86
 await testRunner.ThenAsync(string.Format("Check Total Values \'{0}\' contains", total), ((string)(null)), ((Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("FilterByLaunchNameAndTotal: Demo Api Tests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "LogInTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mytag")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Demo Api Tests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:launchName", "Demo Api Tests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:total", "10")]
        public async System.Threading.Tasks.Task FilterByLaunchNameAndTotal_DemoApiTests()
        {
#line 76
await this.FilterByLaunchNameAndTotal("Demo Api Tests", "10", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("FilterByLaunchNameAndTotal: Demo Api")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "LogInTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mytag")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Demo Api")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:launchName", "Demo Api")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:total", "15")]
        public async System.Threading.Tasks.Task FilterByLaunchNameAndTotal_DemoApi()
        {
#line 76
await this.FilterByLaunchNameAndTotal("Demo Api", "15", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("FilterByLaunchNameAndTotal: Api Tests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "LogInTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mytag")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Api Tests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:launchName", "Api Tests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:total", "20")]
        public async System.Threading.Tasks.Task FilterByLaunchNameAndTotal_ApiTests()
        {
#line 76
await this.FilterByLaunchNameAndTotal("Api Tests", "20", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("FilterByLaunchNameAndTotal: Tests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "LogInTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mytag")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Tests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:launchName", "Tests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:total", "25")]
        public async System.Threading.Tasks.Task FilterByLaunchNameAndTotal_Tests()
        {
#line 76
await this.FilterByLaunchNameAndTotal("Tests", "25", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("FilterByLaunchNameAndTotal: Demo")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "LogInTests")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mytag")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Demo")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:launchName", "Demo")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:total", "30")]
        public async System.Threading.Tasks.Task FilterByLaunchNameAndTotal_Demo()
        {
#line 76
await this.FilterByLaunchNameAndTotal("Demo", "30", ((string[])(null)));
#line hidden
        }
    }
}
#pragma warning restore
#endregion