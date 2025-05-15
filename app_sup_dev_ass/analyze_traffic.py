import sqlite3


def load_queries_from_file(filename):
    with open(filename, "r") as file:
        lines = file.readlines()

    queries = {}
    current_title = None
    current_query = []

    for line in lines:
        stripped = line.strip()
        if stripped.startswith('--'):
            if current_title and current_query:
                queries[current_title] = '\n'.join(current_query).strip()
                current_query = []
            current_title = stripped[2:].strip()
        elif stripped:
            current_query.append(line.rstrip())

    # Add the last query
    if current_title and current_query:
        queries[current_title] = '\n'.join(current_query).strip()

    return queries


output_file = "results.txt"
sql_file = "traffic_analysis.sql"
queries = load_queries_from_file(sql_file)

conn = sqlite3.connect('traffic.db')
cursor = conn.cursor()

with open(output_file, "a") as out:
    out.write("\n=== Task 4: SQL Query Results ===\n")
    for desc, query in queries.items():
        out.write(f"\n--- {desc} ---\n")
        try:
            cursor.execute(query)
            rows = cursor.fetchall()
            if rows:
                for row in rows:
                    out.write(str(row) + "\n")
            else:
                out.write("No results found.\n")
        except Exception as e:
            out.write(f"Error executing query: {e}\n")

conn.close()
