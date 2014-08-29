sqlcmd -S (local) -i "db-init.sql"

C:\Windows\Microsoft.NET\Framework\v4.0.30319\aspnet_regsql.exe -E -S (local) -A all -d phoenix

sqlcmd -S (local) -i "db-hooktoapplservices.sql"

sqlcmd -S (local) -i "db-seed_data.sql"

sqlcmd -S (local) -i "db-hooktoregistrarservices.sql"

sqlcmd -S (local) -i "db-seed_data_Eddie.sql"

sqlcmd -S (local) -i "db-seed_data_Max.sql"

sqlcmd -S (local) -i "db-hooktoregisterservices.sql"

sqlcmd -S (local) -i "db-hooktothirdpartyservices.sql"

sqlcmd -S (local) -i "db-hooktotournamentservices.sql"