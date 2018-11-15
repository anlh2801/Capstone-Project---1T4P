package com.odts.it_supporter_app.models;

import com.google.gson.annotations.SerializedName;

public class RequestTask {
    @SerializedName("RequestId")
    private Integer requestId;
    @SerializedName("RequestTaskId")
    private Integer requestTaskId;
    @SerializedName("TaskStatus")
    private Integer taskStatus;
    @SerializedName("TaskDetail")
    private String taskDetail;
    @SerializedName("CreateByITSupporter")
    private Integer createByITSupporter;
    @SerializedName("StartTime")
    private String startTime;
    @SerializedName("EndTime")
    private String endTime;
    @SerializedName("Priority")
    private Integer priority;
    @SerializedName("PreTaskCondition")
    private Integer preTaskCondition;

    public RequestTask() {

    }

    public Integer getRequestId() {
        return requestId;
    }

    public void setRequestId(Integer requestId) {
        this.requestId = requestId;
    }

    public Integer getRequestTaskId() {
        return requestTaskId;
    }

    public void setRequestTaskId(Integer requestTaskId) {
        this.requestTaskId = requestTaskId;
    }

    public Integer getTaskStatus() {
        return taskStatus;
    }

    public void setTaskStatus(Integer taskStatus) {
        this.taskStatus = taskStatus;
    }

    public String getTaskDetail() {
        return taskDetail;
    }

    public void setTaskDetail(String taskDetail) {
        this.taskDetail = taskDetail;
    }

    public Integer getCreateByITSupporter() {
        return createByITSupporter;
    }

    public void setCreateByITSupporter(Integer createByITSupporter) {
        this.createByITSupporter = createByITSupporter;
    }

    public String getStartTime() {
        return startTime;
    }

    public void setStartTime(String startTime) {
        this.startTime = startTime;
    }

    public String getEndTime() {
        return endTime;
    }

    public void setEndTime(String endTime) {
        this.endTime = endTime;
    }

    public Integer getPriority() {
        return priority;
    }

    public void setPriority(Integer priority) {
        this.priority = priority;
    }

    public Integer getPreTaskCondition() {
        return preTaskCondition;
    }

    public void setPreTaskCondition(Integer preTaskCondition) {
        this.preTaskCondition = preTaskCondition;
    }
}
