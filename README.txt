Version 1_1 - 25/2-2022:

A class Library (CommonStuff) is used to all the stuff that are common for the indexer and the searcher.
- path for indexer
- path for the database
- a type for a document.

Creation time and index time is now part of the search result.

A class (SearchResult) for holding all information from a search is created and used.

The searcher is refactored such that SearchLogic contains all the logic and are prepared
for a Y-spilt.

Version 1_3 9/3-2022:

The y-split of the console app performed. It results in SearchAPI that contains the search logic and access to database.



