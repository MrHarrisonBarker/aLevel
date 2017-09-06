# aLevel

### Sentiment analysis of current trends through twitter data minning.

[![Build Status](https://travis-ci.org/MrHarrisonBarker/aLevel.svg?branch=master)](https://travis-ci.org/MrHarrisonBarker/aLevel)

## Features to impliment

- [x] Basic Twitter querying.
- [ ] User input for Twitter queries.
- [ ] Sentiment analysis of mass tweets.
- [ ] Data visualisation of analysed tweets.
- [ ] Stored credentials in db.
- [ ] Refine desgin.

## Some code

### Basic search function
```
[ActionName("Search")]
public async Task<ActionResult> SearchAsync()

{
  var auth = new MvcAuthorizer
{

  CredentialStore = new SessionStateCredentialStore()
  
};

  var ctx = new TwitterContext(auth);

  var searchResponse =
    await
    (from search in ctx.Search
    where search.Type == SearchType.Search &&
          search.Query == "Donald trump" &&
          search.Count == 200
    select search)
    .SingleOrDefaultAsync();

  var tweets =
  (from tweet in searchResponse.Statuses
    select new TweetSearchModel
    {
      ID = tweet.StatusID,
      ImageUrl = tweet.User.ProfileImageUrl,
      ScreenName = tweet.User.Name,
      Text = tweet.Text,
    })
    .ToList();

  return View(tweets);
}
```
