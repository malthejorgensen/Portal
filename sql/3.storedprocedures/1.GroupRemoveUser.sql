CREATE PROCEDURE `Group_RemoveUser`(
    IN  GroupGUID       BINARY(16),
    IN  UserGUID        BINARY(16),
    IN  RequestUserGUID BINARY(16),
    OUT ErrorCode       INTEGER
)
BEGIN

    IF RequestUserGUID IS NULL OR DoesUserHavePermissionToGroup( RequestUserGUID, GroupGUID, 'REMOVE_USER' ) = 1 THEN
		DELETE FROM Group_User_Join AS guj WHERE guj.GroupGUID = GroupGUID AND guj.UserGUID = UserGUID LIMIT 1
             
        SET ErrorCode = 1;
    ELSE
        SET ErrorCode = -100;
    END IF;

END