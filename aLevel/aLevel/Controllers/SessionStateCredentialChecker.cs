using LinqToTwitter;



namespace aLevel.Controllers
{
	public class SessionStateCredentialChecker : ICredentialChecker
	{
		public bool HasCredentials()
		{
			return new SessionStateCredentialStore().HasAllCredentials();
		}
	}
}