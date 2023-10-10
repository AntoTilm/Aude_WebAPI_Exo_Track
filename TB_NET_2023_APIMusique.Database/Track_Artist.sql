﻿CREATE TABLE [dbo].[Track_Artist]
(
	[TRACK_ID] INT,
	[ARTIST_ID] INT,
	[FEATURING] BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_TRACK_ARTIST PRIMARY KEY ([TRACK_ID],[ARTIST_ID]),
	CONSTRAINT FK_TRACK_ARTIST__ARTIST FOREIGN KEY ([TRACK_ID])
		REFERENCES TRACK([ID_TRACK]) ON DELETE CASCADE,
	CONSTRAINT FK_TRACK_ARTIST__TRACK FOREIGN KEY ([ARTIST_ID])
		REFERENCES ARTIST([ID_ARTIST])
)
