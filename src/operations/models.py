from datetime import datetime

from sqlalchemy import MetaData, Table, Column, Integer, String, TIMESTAMP

metadata = MetaData()

operation = Table(
    "operation",
    metadata,
    Column("id", Integer, primary_key=True),
    Column("quantity", String),
    Column("figi", String),
    Column("instrument_type", String, nullable=True),
    Column("date", TIMESTAMP),
    Column("type", String),
)

test_data = [
    {'quantity': '100', 'figi': 'BBG000B9XRY4', 'instrument_type': 'stock', 'date': datetime(2024, 5, 23, 10, 0), 'type': 'buy'},
    {'quantity': '200', 'figi': 'BBG000C3H4H3', 'instrument_type': 'bond', 'date': datetime(2024, 5, 23, 11, 0), 'type': 'sell'},
    {'quantity': '150', 'figi': 'BBG000BBQCY9', 'instrument_type': 'etf', 'date': datetime(2024, 5, 23, 12, 0), 'type': 'buy'},
    {'quantity': '300', 'figi': 'BBG000BDTBL9', 'instrument_type': 'stock', 'date': datetime(2024, 5, 23, 13, 0), 'type': 'buy'},
    {'quantity': '250', 'figi': 'BBG000BPFCR5', 'instrument_type': 'currency', 'date': datetime(2024, 5, 23, 14, 0), 'type': 'sell'}
]
