SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS paymentSource;
SET FOREIGN_KEY_CHECKS = 1;

CREATE TABLE `paymentSource` (
	paymentSourceId INT NOT NULL AUTO_INCREMENT,
	`source` VARCHAR(100),
	PRIMARY KEY(`paymentSourceId`)

)
COLLATE='utf8_general_ci'
ENGINE=InnoDB
;
SET @currDate = CURDATE();

INSERT INTO paymentSource VALUES(1,'Direct Debit');
INSERT INTO paymentSource VALUES(2,'PayPoint');
INSERT INTO paymentSource VALUES(3,'Cash');
