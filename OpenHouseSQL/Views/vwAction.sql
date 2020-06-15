DROP VIEW IF EXISTS `vwAction`;

CREATE VIEW `vwAction` AS
SELECT
	action.actionId, 
	action.actionTypeId, 
	actiontype.actionType, 
	action.tenancyId, 
	vwtenancy.propertyId,
	vwtenancy.contactAddress, 
	action.actionDueDate, 
	action.actionCompletedDate, 
	action.updatedByUserID, 
	action.updatedDT, 
	action.createdByUserID, 
	action.createdDT, 
	action.assignedUserId,
	vwuser.UserName AS assignedUsername
FROM
	action
	INNER JOIN
	actiontype
	ON 
		action.actionTypeId = actiontype.actionTypeId
	INNER JOIN
	vwtenancy
	ON 
		action.tenancyId = vwtenancy.tenancyId
	INNER JOIN
	vwuser
	ON
		action.assignedUserId = vwUser.Id