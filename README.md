# SysAdmDip

文章張貼 Knowlege

Member: 
  [key] int Member_Id
  string Member_Name
  string Member_Account
  string Member_Password
  string Member_Email
  int Member_RoleId
  int Member_Active
  int Member_CreaterId
  DateTime Member_CreateDate
  List<MemberKnowlege> MemberKnowlege
MemberKnowlege:
  [key] int MemberKnowlege_Id
  int MemberId
  int KnowlegeId
  string MemberKnowlege_Characteristic 性質
  M
