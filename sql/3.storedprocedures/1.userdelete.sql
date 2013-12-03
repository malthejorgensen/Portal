DELIMITER //

CREATE PROCEDURE `User_Delete`(
    Guid    BINARY(16)
)
BEGIN

	DELETE FROM `User`
		WHERE GUID = Guid
		LIMIT 1;

    SELECT ROW_COUNT();
END //
