# PresentationModelLunchAndLearn
Code samples for lunch &amp; learn over presentation models @feature23

Use case:
A case sheet is a form that's completed during a medical procedure that tracks which products were used so a vendor can get paid for them in the future. Our application hosts multiple vendors, so individual vendors can create and view their own existing case sheets, and internal processors can view case sheets for all vendors and process ones that need processing (generally, this would be much more involved than setting a flag, but #demo).

This is actually a pretty complex business environment, so I've simplified it as much as I can so we don't get bogged down into business rules but can still highlight the strategies in place to support this complex and ever-evolving business environment.

Overall solution structure:

- SQL Views to flatten normalized data.
- Read models in domain that consume the SQL views.
- Repositories for data access; consumers are ignorant as to which methods access views vs. tables.
- Services for data mutation.
- Presentation model for wrapping read views along w/ permissions and other, view-related properties.
- Presentation model is in a separate project to allow multiple web projects to utilize the same code.
- Dependency manager project to handle our dependencies to keep abstractions over implementation strategies.
- Web projects so we can use everything above.

Tech stack:

- ASP.NET Core 2.0
- EF on full .NET framework (yes, Windows required)
- ReactJS/TypeScript/Rigby for interactive pages.

Run the sample:

0. Clone
1. Publish F23.PresentationModelLnL.Storage.SqlServer\LocalDropRecreate.publish.xml (assumes default SQL Express installation, else modify as needed)
2. npm install on Web.VendorPortal & set that as startup project
3. Run in VS2017, go over Case Sheets link in main menu first, then process link
