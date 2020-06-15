DROP VIEW IF EXISTS `vwUser`;

CREATE VIEW `vwUser` AS
SELECT
	  Id
	 ,UserName
	 ,Email
FROM
	openhouse_auth.aspnetusers