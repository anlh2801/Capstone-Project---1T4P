package com.odts.it_supporter_app.models;

import com.google.gson.annotations.SerializedName;

public class RequestTask {
    @SerializedName("RequestId")
    private Integer requestId;
    @SerializedName("RequestTaskId")
    private Integer requestTaskId;
    @SerializedName("TaskStatus")
    private Integer taskStatus;
    @SerializedName("CreateByITSupporter")
    private Integer createByITSupporter;
    @SerializedName("StartTime")
    private Integer startTime;
    @SerializedName("EndTime")
    private Integer endTime;
    @SerializedName("Priority")
    private Integer priority;
    @SerializedName("PreTaskCondition")
    private Integer preTaskCondition;

    public RequestTask(Integer requestId) {
        this.requestId = requestId;
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

    public Integer getCreateByITSupporter() {
        return createByITSupporter;
    }

    public void setCreateByITSupporter(Integer createByITSupporter) {
        this.createByITSupporter = createByITSupporter;
    }

    public Integer getStartTime() {
        return startTime;
    }

    public void setStartTime(Integer startTime) {
        this.startTime = startTime;
    }

    public Integer getEndTime() {
        return endTime;
    }

    public void setEndTime(Integer endTime) {
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
