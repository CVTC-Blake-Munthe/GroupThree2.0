DROP TABLE IF EXISTS Guest
CREATE TABLE [dbo].[Guest] (
[GuestID] [int] NOT NULL IDENTITY,
[FirstName] [nvarchar](max),
[MiddleInitial] [nvarchar](max),
[LastName] [nvarchar](max),
[Gender] [nvarchar](max),
[DateOfBirth] [datetime],
[SocialSecurity] [nvarchar](max),
[PhoneNumber] [nvarchar](max),
[Services] [nvarchar](max),
[Picture] [nvarchar](max),
[IntakeComplete] [BIT],
CONSTRAINT [PK_dbo.Guest] PRIMARY KEY ([GuestID])
)

DROP TABLE IF EXISTS Calendar
CREATE TABLE [dbo].Calendar (
[CalendarID] [int] NOT NULL IDENTITY,
[CalendarDate] [datetime],
CONSTRAINT [PK_dbo.Calendar] PRIMARY KEY ([CalendarID])
)


DECLARE @StartDate DATETIME
DECLARE @EndDate DATETIME
SET @StartDate = GETDATE()
SET @EndDate = DATEADD(d, 365, @StartDate)

WHILE @StartDate <= @EndDate
      BEGIN
             INSERT INTO [Calendar]
             (
                   CalendarDate
             )
             SELECT
                   @StartDate

             SET @StartDate = DATEADD(dd, 1, @StartDate)
      END

DROP TABLE IF EXISTS EmergencyContact
CREATE TABLE [dbo].EmergencyContact (
[ContactID] [int] NOT NULL IDENTITY,
[GuestID] [int] NOT NULL,
[ContactFName] [nvarchar](max),
[ContactLName] [nvarchar](max),
[ContactPhone] [nvarchar](max),
[ContactRelation] [nvarchar](max),
CONSTRAINT [PK_dbo.EmergencyContact] PRIMARY KEY ([ContactID])
)

DROP TABLE IF EXISTS Rules
CREATE TABLE [dbo].Rules (
[RuleID] [int] NOT NULL IDENTITY,
[RuleNo] [int],
[RuleText] [nvarchar](max),
CONSTRAINT [PK_dbo.Rules] PRIMARY KEY ([RuleID])
)

DROP TABLE IF EXISTS Stays
CREATE TABLE [dbo].Stays (
[GuestID] [int] NOT NULL,
[CalendarID] [int] NOT NULL,
CONSTRAINT [PK_dbo.Stays] PRIMARY KEY ([GuestID],[CalendarID])
)

DROP TABLE IF EXISTS Strikes
CREATE TABLE [dbo].Strikes (
[StrikeID] [int] NOT NULL IDENTITY,
[GuestID] [int] NOT NULL,
[CalendarID] [int] NOT NULL,
[RuleID] [int] NOT NULL,
[Notes] [nvarchar](max),
[StrikeOutWarning] [nvarchar](max),
CONSTRAINT [PK_dbo.Strikes] PRIMARY KEY ([StrikeID])
)