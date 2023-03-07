SELECT UserName,UserMailId,jn.JobName,jt.JobTypeName,jl.JobLocationName               
From JobApplication j
INNER JOIN JobName jn on
j.JobId = jn.JobId
INNER JOIN JobType jt on
j.JobTypeId =jt.JobTypeId
INNER JOIN JobLocation jl on
j.JobLocationId=jl.JobLocationId

go
exec dbo.JobDetails
go
