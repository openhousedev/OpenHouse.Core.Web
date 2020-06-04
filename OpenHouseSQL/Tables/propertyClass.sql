SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS propertyclass;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `propertyClass` (
	`propertyClassId` INT NOT NULL AUTO_INCREMENT,
	`propertyClass` VARCHAR(100) NULL DEFAULT NULL,
	PRIMARY KEY(`propertyClassId`) USING BTREE
)
COLLATE='utf8_general_ci'
ENGINE=InnoDB
;

INSERT INTO propertyClass VALUES(1,'Street');
INSERT INTO propertyClass VALUES(2,'Block');
INSERT INTO propertyClass VALUES(3,'House');
INSERT INTO propertyClass VALUES(4,'Garage');
