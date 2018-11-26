package com.odts.it_supporter_app.apiCaller;

import com.odts.it_supporter_app.models.Guideline;
import com.odts.it_supporter_app.models.RequestTask;
import com.odts.it_supporter_app.utils.ResponseObject;
import com.odts.it_supporter_app.utils.ResponseObjectReturnList;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.POST;
import retrofit2.http.PUT;
import retrofit2.http.Path;
import retrofit2.http.Query;

public interface ITaskApiCaller {
    @GET("ITsuportter/all_task_by_requestId/{requestId}")
    Call<ResponseObjectReturnList<RequestTask>> getTaskByRequestID(@Path("requestId") int requestId);

    @POST("ITsuportter/create_task")
    Call<ResponseObject<Boolean>> createTask(@Body RequestTask task);

    @PUT("ITsuportter/update_task_status")
    Call<ResponseObject<Boolean>> updateTaskStatus(@Query("requestTaskId") Integer requestTaskId ,
                                                    @Query("isDone") Boolean isDone);

    @PUT("ITsuportter/delete_task")
    Call<ResponseObject<Boolean>> deleteTask(@Query("requestTaskId") Integer requestTaskId );
}
