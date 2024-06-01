from fastapi import APIRouter, Depends
from sqlalchemy import select, insert
from sqlalchemy.ext.asyncio import AsyncSession
from fastapi_cache.decorator import cache

from src.auth.base_config import current_user
from src.auth.models import User
from src.database import get_async_session
from src.operations.models import operation
from src.operations.schemas import OperationCreate

router = APIRouter(
    prefix="/operations",
    tags=["Operation"],
)


@router.get("/long")
@cache(expire=60)
async def index():
    return dict(hello="world")

@router.get("/")
async def get_specific_operations(operation_type: str, session: AsyncSession = Depends(get_async_session)):
    query = select(operation).where(operation.c.type == operation_type)
    result = await session.execute(query)
    return result.mappings().all()


@router.post("/")
async def add_spefific_operations(
        new_operation: OperationCreate,
        session: AsyncSession = Depends(get_async_session),
        user: User = Depends(current_user)):
    statment = insert(operation).values(**new_operation.dict())
    await session.execute(statment)
    await session.commit() # Чтобы транкзакция завершилась
    return {"status": "success"}
