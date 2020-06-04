SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS alertType;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `alertType` (
	`alertTypeId` INT NOT NULL,
	`alertType` VARCHAR(100),
	PRIMARY KEY(`alertTypeId`)
)

COLLATE='utf8_general_ci'
ENGINE=InnoDB
;

INSERT INTO `alertType` VALUES(1,'INFORMATION');
INSERT INTO `alertType` VALUES(2,'SAFETY');
INSERT INTO `alertType` VALUES(3,'DISABILITY');

