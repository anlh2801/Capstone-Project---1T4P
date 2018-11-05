package com.odts.apiCaller;

import com.odts.models.Request;
import com.odts.utils.ResponseObject;
import com.odts.utils.ResponseObjectReturnList;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.POST;
import retrofit2.http.Path;
import retrofit2.http.Query;

public interface IRequestApiCaller {
    @POST("agency/create_request")
    Call<ResponseObject<Integer>> createRequest(@Body Request request);

    @GET("ticket/all_ticket_with_status_agency")
    Call<ResponseObjectReturnList<Request>> getRequestByStatus(@Query("agency_id") Integer agency_id,
                                                                   @Query("status") Integer status_id);
    @GET("request/view_request_detail")
    Call<ResponseObject<Request>> requestDetail(@Query("requestId") Integer request_id);

    @POST("ticket/update_status_ticket")
    Call<ResponseObject<Boolean>> cancelTicket(@Query("request_id") Integer request_id,
                                        @Query("status") Integer status_id);

    @GET("/agency/find_itSupporter_by_requestId/{requestId}")
    Call<String> findITSupporterByRequestId(@Path("requestId") int requestId);
}
