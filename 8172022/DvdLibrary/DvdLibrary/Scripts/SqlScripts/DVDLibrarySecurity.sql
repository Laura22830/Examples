Use DVDLibrary
GO

CREATE LOGIN DVDLibraryApp WITH PASSWORD='testing123';
GO

CREATE USER DVDLibraryApp FOR LOGIN DVDLibraryApp;
GO

GRANT EXEC TO DVDLibraryApp;

GRANT SELECT, UPDATE, INSERT, DELETE TO DVDLibraryApp;