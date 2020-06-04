SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS propertyType;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `propertyType` (
	`propertyTypeId` INT NOT NULL,
	`propertyType` VARCHAR(100) NULL DEFAULT NULL,
	PRIMARY KEY(`propertyTypeId`)
)
COLLATE='utf8_general_ci'
ENGINE=InnoDB
;

INSERT INTO propertyType VALUES(1,'Semi-Detached House');
INSERT INTO propertyType VALUES(2,'Detached');
INSERT INTO propertyType VALUES(3,'Street');
INSERT INTO propertyType VALUES(4,'Cottage');
INSERT INTO propertyType VALUES(5,'Bungalow');
INSERT INTO propertyType VALUES(6,'Appartment');
INSERT INTO propertyType VALUES(7,'Bedsit');
INSERT INTO propertyType VALUES(8,'High Rise');