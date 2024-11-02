export interface ApiResult<T> {
  data: T[];
  paginationInfo: PaginationInfo;
}

interface PaginationInfo {
  page: number;
  pageSize: number;
  total: number;
}
