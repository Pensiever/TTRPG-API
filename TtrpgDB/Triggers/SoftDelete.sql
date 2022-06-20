CREATE TRIGGER [SoftDelete]
ON [dbo].[Questers]
INSTEAD OF DELETE
AS
BEGIN
	UPDATE [Questers] SET IsActive = 0 WHERE Id = (SELECT Id FROM deleted)
END
