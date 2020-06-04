SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS tenancyTerminationReason;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `tenancyTerminationReason` (
	`tenancyTerminationReasonId` INT NOT NULL AUTO_INCREMENT,
	`terminationReason` VARCHAR(100) NULL DEFAULT NULL,
	PRIMARY KEY(`tenancyTerminationReasonId`)
)
COLLATE='utf8_general_ci'
ENGINE=InnoDB
;

INSERT INTO tenancyTerminationReason VALUES(1,'Relocation');
INSERT INTO tenancyTerminationReason VALUES(2,'Cost');
INSERT INTO tenancyTerminationReason VALUES(3,'Deceased');
INSERT INTO tenancyTerminationReason VALUES(4,'Evicted');
INSERT INTO tenancyTerminationReason VALUES(5,'Property too large');
INSERT INTO tenancyTerminationReason VALUES(6,'Property too small');
