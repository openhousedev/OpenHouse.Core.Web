SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS relationship;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `relationship` (
	`relationshipId` INT NOT NULL AUTO_INCREMENT,
	`relationship` VARCHAR(100),
	PRIMARY KEY(`relationshipId`)
)

COLLATE='utf8_general_ci'
ENGINE=InnoDB
;
SET @currDate = CURDATE();

INSERT INTO relationship VALUES(1,'None');
INSERT INTO relationship VALUES(2,'Wife');
INSERT INTO relationship VALUES(3,'Husband');
INSERT INTO relationship VALUES(4,'Partner');
INSERT INTO relationship VALUES(5,'Child');
INSERT INTO relationship VALUES(6,'Niece');
INSERT INTO relationship VALUES(7,'Nephew');
INSERT INTO relationship VALUES(8,'Brother');
INSERT INTO relationship VALUES(9,'Sister');
INSERT INTO relationship VALUES(10,'Parent');