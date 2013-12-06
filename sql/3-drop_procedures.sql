DROP PROCEDURE IF EXISTS Group_RemoveUser;
DROP PROCEDURE IF EXISTS Group_UpdateUserPermissions;
DROP PROCEDURE IF EXISTS ClientSetting_Create;
DROP PROCEDURE IF EXISTS ClientSettings_Get;
DROP PROCEDURE IF EXISTS ClientSettings_Set;
DROP PROCEDURE IF EXISTS `Group_AssociateWithUser`;
DROP PROCEDURE IF EXISTS `Group_Create`;
DROP PROCEDURE IF EXISTS `Group_Delete`;
DROP PROCEDURE IF EXISTS `Group_Get`;
DROP PROCEDURE IF EXISTS `Group_Update`;
DROP PROCEDURE IF EXISTS `IndexSettings_Create`;
DROP PROCEDURE IF EXISTS `IndexSettings_Get`;
DROP PROCEDURE IF EXISTS `Log_Create`;
DROP PROCEDURE IF EXISTS `Module_Create`;
DROP PROCEDURE IF EXISTS `Module_Get`;
DROP PROCEDURE IF EXISTS `Permission_Create`;
DROP PROCEDURE IF EXISTS Session_Create;
DROP PROCEDURE IF EXISTS `Session_Delete`;
DROP PROCEDURE IF EXISTS `Session_Get`;
DROP PROCEDURE IF EXISTS `Session_Update`;
DROP PROCEDURE IF EXISTS `Subscription_Create`;
DROP PROCEDURE IF EXISTS `Subscription_Delete`;
DROP PROCEDURE IF EXISTS `SubscriptionInfo_Get`;
DROP PROCEDURE IF EXISTS `Subscription_Update`;
DROP PROCEDURE IF EXISTS `Ticket_Create`;
DROP PROCEDURE IF EXISTS `Ticket_Get`;
DROP PROCEDURE IF EXISTS `Ticket_Use`;
DROP PROCEDURE IF EXISTS `User_Create`;
DROP PROCEDURE IF EXISTS `User_Delete`;
DROP PROCEDURE IF EXISTS `User_Get`;
DROP PROCEDURE IF EXISTS `UserInfo_Get`;
DROP PROCEDURE IF EXISTS UserInfo_GetWithGroupPermission;
DROP PROCEDURE IF EXISTS `UserSettings_Delete`;
DROP PROCEDURE IF EXISTS `UserSettings_Get`;
DROP PROCEDURE IF EXISTS UserSettings_Set;
DROP FUNCTION IF EXISTS DoesUserHavePermissionToGroup;
DROP FUNCTION IF EXISTS `DoesUserHavePermissionToSubscription`;
DROP FUNCTION IF EXISTS DoesUserHavePermissionToSystem;
DROP FUNCTION IF EXISTS `GetPermissionForAction`;
DROP FUNCTION IF EXISTS `GetUsersHighestSystemPermission`;