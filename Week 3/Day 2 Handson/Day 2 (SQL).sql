/* 1. Create the Database */
CREATE DATABASE EventDb;
GO
USE EventDb;
GO

/* 2. Create UserInfo Table */
CREATE TABLE UserInfo (
    EmailId VARCHAR(255) PRIMARY KEY,
    UserName VARCHAR(50) NOT NULL,    
    [Role] VARCHAR(20) NOT NULL CHECK ([Role] IN ('Admin', 'Participant')), 
    [Password] VARCHAR(20) NOT NULL CHECK (LEN([Password]) BETWEEN 6 AND 20)
);

/* 3. Create EventDetails Table */
CREATE TABLE EventDetails (
    EventId INT PRIMARY KEY,     
    EventName VARCHAR(50) NOT NULL,    
    EventCategory VARCHAR(50) NOT NULL, 
    EventDate DATETIME NOT NULL,      
    [Description] VARCHAR(MAX) NULL,  
    [Status] VARCHAR(15) CHECK ([Status] IN ('Active', 'In-Active'))
);

/* 4. Create SpeakersDetails Table */
CREATE TABLE SpeakersDetails (
    SpeakerId INT PRIMARY KEY,       
    SpeakerName VARCHAR(50) NOT NULL  
);

/* 5. Create SessionInfo Table */
CREATE TABLE SessionInfo (
    SessionId INT PRIMARY KEY,       
    EventId INT NOT NULL,           
    SessionTitle VARCHAR(50) NOT NULL,
    SpeakerId INT NOT NULL,          
    [Description] VARCHAR(MAX) NULL,  
    SessionStart DATETIME NOT NULL,   
    SessionEnd DATETIME NOT NULL,    
    SessionUrl VARCHAR(255),          
    
    CONSTRAINT FK_Session_Event FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),
    CONSTRAINT FK_Session_Speaker FOREIGN KEY (SpeakerId) REFERENCES SpeakersDetails(SpeakerId)
);

/* 6. Create ParticipantEventDetails Table */
CREATE TABLE ParticipantEventDetails (
    Id INT PRIMARY KEY,              
    ParticipantEmailId VARCHAR(255) NOT NULL,
    EventId INT NOT NULL,            
    SessionId INT NOT NULL,          
    IsAttended BIT NOT NULL,         
    
    CONSTRAINT FK_Part_User FOREIGN KEY (ParticipantEmailId) REFERENCES UserInfo(EmailId),
    CONSTRAINT FK_Part_Event FOREIGN KEY (EventId) REFERENCES EventDetails(EventId),
    CONSTRAINT FK_Part_Session FOREIGN KEY (SessionId) REFERENCES SessionInfo(SessionId)
);