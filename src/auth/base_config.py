from fastapi_users.authentication import CookieTransport
from fastapi_users.authentication import AuthenticationBackend, BearerTransport, JWTStrategy

cookie_transport = CookieTransport(cookie_name="bounds", cookie_max_age=3600)

SECRET = "SECRET" # Перенести в хранилище .env


def get_jwt_strategy() -> JWTStrategy:
    return JWTStrategy(secret=SECRET, lifetime_seconds=3600)


auth_backend = AuthenticationBackend(
    name="jwt",
    transport=cookie_transport,
    get_strategy=get_jwt_strategy,
)