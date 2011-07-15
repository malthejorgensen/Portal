IF( 1 = 1 )
BEGIN

	DELETE FROM [Session]
	DELETE FROM Subscription_User_Join
	DELETE FROM Subscription
	DELETE FROM AuthenticationProvider_User_Join
	DELETE FROM [User]
	DELETE FROM ClientSetting
	DELETE FROM XmlType
	DELETE FROM Module
	DELETE FROM Extension
	DELETE FROM Permission
	DELETE FROM AuthenticationProvider

END

DBCC CHECKIDENT ("AuthenticationProvider", RESEED,0)
DBCC CHECKIDENT ("Subscription", RESEED,0)
DBCC CHECKIDENT ("[User]", RESEED,0)
DBCC CHECKIDENT ("Module", RESEED,0)
DBCC CHECKIDENT ("Extension", RESEED,0)

DECLARE @SubscriptionIdentifier UNIQUEIDENTIFIER
SET @SubscriptionIdentifier = NEWID()

EXECUTE Subscription_Insert @GUID = @SubscriptionIdentifier, @Name = 'Geckon'
EXECUTE User_Insert @Firstname = 'Anonymous', @Email = 'Anonymous@Geckon.com'
EXECUTE XmlType_Insert 1, 'XML'
EXECUTE ClientSetting_Insert 1, 1
EXECUTE Extension_Insert 'Session', 'Geckon.Portal.Extensions.Standard.SessionExtension','Geckon.Portal.Extensions.Standard.dll'
EXECUTE Extension_Insert 'User', 'Geckon.Portal.Extensions.Standard.UserExtension','Geckon.Portal.Extensions.Standard.dll'
EXECUTE AuthenticationProvider_Insert 'Email Password'



INSERT INTO [Permission]([TableIdentifier],[RightName],[Permission],[Description]) VALUES ('Subscription','Create User',1,'Permissoin to Create new users')