	DROP VIEW IF EXISTS `vwAlert`;

	CREATE VIEW `vwAlert` AS
	SELECT DISTINCT
		 ta.tenancyAlertId
	  , ta.tenancyId
	  , a.alertId
	  , a.alertTypeId
	  , a.alertText
	  , a.startDT
	  , a.endDT
	  , a.updatedByUserID
	  , uu.UserName AS updateByUsername
	  , updatedDT
	  , createdByUserID
	  , cu.UserName AS createdByUsername
	  , createdDT
	FROM 
		alert a
	INNER JOIN
		tenancyalert ta
	ON
		a.alertId = ta.alertId
	INNER JOIN
		vwuser uu
	ON
		a.updatedByUserId = uu.Id
	INNER JOIN
		vwuser cu
	ON
		a.createdByUserId = cu.Id
		
	