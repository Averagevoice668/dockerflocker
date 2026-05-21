FROM mcr.microsoft.com/mssql/server:2022-latest

ENV ACCEPT_EULA=Y
ENV MSSQL_PID=Express
ENV MSSQL_SA_PASSWORD=Password1!

USER root
RUN mkdir -p /app/init-scripts && chown mssql /app/init-scripts

COPY ./ChickDB/init-database.sql /app/init-scripts/

ENV PATH="$PATH:/opt/mssql-tools18/bin"

USER mssql

HEALTHCHECK --interval=10s --timeout=5s --start-period=30s --retries=5 \
    CMD /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P "$MSSQL_SA_PASSWORD" -C -Q "SELECT 1" || exit 1

CMD /bin/bash -c "/opt/mssql/bin/sqlservr & \
    sleep 25 && \
    if /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P '$MSSQL_SA_PASSWORD' -C -Q 'SELECT name FROM sys.databases WHERE name = \"Farm\"' | grep -q Farm; then\
    echo 'Database already exists'; then \
        echo 'Database already exists'; \
    else \
        echo 'Initializing database...'; \
        /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P '$MSSQL_SA_PASSWORD' -C -d master -i /app/init-scripts/init-database.sql; \
    fi && wait"