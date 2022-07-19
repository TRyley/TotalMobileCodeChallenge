CREATE TABLE [dbo].[Shifts] (
    [Shift_ID]    INT          IDENTITY (1, 1) NOT NULL,
    [Shift_Start] DATETIME     NOT NULL,
    [Shift_End]   DATETIME     NOT NULL,
    [Shift_Name]  VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Shifts] PRIMARY KEY CLUSTERED ([Shift_ID] ASC)
);

