--Play Reset Code
--Sets all passwords to play, Sets the company name to 'Play Play Play' 
--and sets the 'Play Database' checkbox in system settings to checked.
UPDATE    SY_Passwords
SET              Password = '|gp~'
                          UPDATE    System
                           SET              Company_Name = 'Play Play Play'
                                                      UPDATE    System
                                                       SET              Play_Database = 'True'