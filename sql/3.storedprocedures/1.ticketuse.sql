DELIMITER //

CREATE PROCEDURE `Ticket_Use`(
    IN  WhereGUID   BINARY(16)
)
BEGIN

    UPDATE  Ticket
       SET  DateUsed = NOW()
     WHERE  GUID = WhereGUID;

    SELECT ROW_COUNT();

END //