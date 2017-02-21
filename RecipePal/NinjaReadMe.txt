
----------------------------------------------------------------------------------------------------
21 Feb 17 21:20 Add Projects
----------------------------------------------------------------------------------------------------
RecipePal.Core project successfully added. (template NinjaCoder.Core.zip)
RecipePal.Droid project successfully added. (template NinjaCoder.Droid.zip)
RecipePal.iOS project successfully added. (template NinjaCoder.iOS.zip)

----------------------------------------------------------------------------------------------------
Options
----------------------------------------------------------------------------------------------------
MvvmCross framework selected.
NUnit testing framework selected.
Moq mocking framework selected.
StartUp Project set to Droid
iOS View Type StoryBoard selected.

MainViewModel.cs added to RecipePal.Core project (template=MvxSampleDataViewModel.t4)
MainView.cs added to RecipePal.iOS project (template=SampleData\StoryBoard\View.t4)
MainView.cs added to RecipePal.Droid project (template=SampleDataView.t4)

----------------------------------------------------------------------------------------------------
Nuget Commands
----------------------------------------------------------------------------------------------------

Install-Package MvvmCross -FileConflictAction Overwrite -ProjectName RecipePal.Core 
Install-Package Scorchio.NinjaCoder.MvvmCross.Core -FileConflictAction Overwrite -ProjectName RecipePal.Core 
Install-Package MvvmCross -FileConflictAction Overwrite -ProjectName RecipePal.Droid 
Install-Package Scorchio.NinjaCoder.MvvmCross -FileConflictAction ignore -ProjectName RecipePal.Droid 
Install-Package MvvmCross -FileConflictAction Overwrite -ProjectName RecipePal.iOS 
Install-Package Scorchio.NinjaCoder.MvvmCross -FileConflictAction ignore -ProjectName RecipePal.iOS 
Install-Package Scorchio.NinjaCoder.MvvmCross.iOS.StoryBoard -FileConflictAction Overwrite -ProjectName RecipePal.iOS
Install-Package Scorchio.NinjaCoder.MvvmHelper.Core -FileConflictAction ignore -ProjectName RecipePal.Core


----------------------------------------------------------------------------------------------------
Ninja Coder for MvvmCross and Xamarin Forms v4.2.1
----------------------------------------------------------------------------------------------------

All feedback welcome, please get in touch via twitter.

Issues Log http://github.com/asudbury/NinjaCoderForMvvmCross/issues

Thanks

@asudbury
