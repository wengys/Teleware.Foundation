using System;
using Teleware.Foundation.Domain.Entity;

namespace Teleware.FJJG.DataPump.Entity
{
    /// <summary>
    /// 验收阶段信息
    /// </summary>
    public class ZZ_YS : AbstractRootEntity
    {
        /// <summary>
        /// 项目基本信息外键
        /// </summary>
        public string JBXX_SEC { get; set; }

        /// <summary>
        /// 等别评定单位
        /// </summary>
        public string YS_CX_DBPDDW { get; set; }

        /// <summary>
        /// 工矿废弃地复垦面积
        /// </summary>
        public decimal? YS_CX_GKFQFK { get; set; }

        /// <summary>
        /// 废弃居民点复垦面积
        /// </summary>
        public decimal? YS_CX_JMFQFK { get; set; }

        /// <summary>
        /// 迁村并点减少的村庄数量
        /// </summary>
        public long YS_CX_JSCZSL { get; set; }

        /// <summary>
        /// 新增和改善节水灌溉面积（公顷）
        /// </summary>
        public decimal? YS_CX_JSGGMJ { get; set; }

        /// <summary>
        /// 项目区建设后耕地平均质量等级
        /// </summary>
        public string YS_CX_JSHGDZLDJ { get; set; }

        /// <summary>
        /// 项目区建设前耕地平均质量等级
        /// </summary>
        public string YS_CX_JSQGDZLDJ { get; set; }

        /// <summary>
        /// 新增和改善农田防涝面积
        /// </summary>
        public decimal? YS_CX_NTFLMJ { get; set; }

        /// <summary>
        /// 新增和改善农田灌溉面积（公顷）
        /// </summary>
        public decimal? YS_CX_NTGGMJ { get; set; }

        /// <summary>
        /// 农民人均新增年均纯收入（元）
        /// </summary>
        public decimal? YS_CX_RJXZCSR { get; set; }

        /// <summary>
        /// 水土流失治理面积（公顷）
        /// </summary>
        public decimal? YS_CX_STLSZL { get; set; }

        /// <summary>
        /// 项目建设受益人数（人）
        /// </summary>
        public long YS_CX_XMJSSYR { get; set; }

        /// <summary>
        /// 新增粮食产能（公斤）
        /// </summary>
        public decimal? YS_CX_XZLSCN { get; set; }

        /// <summary>
        /// 新建和改建中心村数量（个）
        /// </summary>
        public long YS_CX_ZXCSL { get; set; }

        /// <summary>
        /// 核减时间
        /// </summary>
        public DateTime? YS_DC_HJSJ { get; set; }

        /// <summary>
        /// 核减原因
        /// </summary>
        public string YS_DC_HJYY { get; set; }

        /// <summary>
        /// 核减指标
        /// </summary>
        public string YS_DC_HJZB { get; set; }

        /// <summary>
        /// 泵站
        /// </summary>
        public long YS_GCL_BZ { get; set; }

        /// <summary>
        /// 低压输电线路
        /// </summary>
        public decimal? YS_GCL_DYSPDXL { get; set; }

        /// <summary>
        /// 灌、排（渠）、管道（中央支持自动计划，一般项目手动填写）
        /// </summary>
        public decimal? YS_GCL_GD { get; set; }

        /// <summary>
        /// 骨干管道（中央支持）
        /// </summary>
        public decimal? YS_GCL_GD_GGGD { get; set; }

        /// <summary>
        /// 骨干渠道（中央支持）
        /// </summary>
        public decimal? YS_GCL_GD_GGQD { get; set; }

        /// <summary>
        /// 新建灌、排（渠）、管道（中央支持）
        /// </summary>
        public decimal? YS_GCL_GD_XJ { get; set; }

        /// <summary>
        /// 高压输配电线路
        /// </summary>
        public decimal? YS_GCL_GYSPDXL { get; set; }

        /// <summary>
        /// 农田防护林工程量（株）
        /// </summary>
        public decimal? YS_GCL_NTFHLGCL { get; set; }

        /// <summary>
        /// 农用井
        /// </summary>
        public long YS_GCL_NYJ { get; set; }

        /// <summary>
        /// 农用桥、涵
        /// </summary>
        public long YS_GCL_NYQ { get; set; }

        /// <summary>
        /// 土地平整面积（公顷）
        /// </summary>
        public decimal? YS_GCL_PZMJ { get; set; }

        /// <summary>
        /// 土方工程量（立方米）
        /// </summary>
        public decimal? YS_GCL_TFGCL { get; set; }

        /// <summary>
        /// 田间道路工程量（中央支持自动计划，一般项目手动填写）
        /// </summary>
        public decimal? YS_GCL_TJDLGC { get; set; }

        /// <summary>
        /// 生产路（中央支持）
        /// </summary>
        public decimal? YS_GCL_TJDLGC_SCL { get; set; }

        /// <summary>
        /// 田间道（中央支持）
        /// </summary>
        public decimal? YS_GCL_TJDLGC_TJL { get; set; }

        /// <summary>
        /// 蓄水池
        /// </summary>
        public long YS_GCL_XSC { get; set; }

        /// <summary>
        /// 复垦规模（公顷）
        /// </summary>
        public decimal? YS_GM_FK { get; set; }

        /// <summary>
        /// 建成高标准基本农田规模
        /// </summary>
        public decimal? YS_GM_GBL { get; set; }

        /// <summary>
        /// 高标准基本农田建设条件
        /// </summary>
        public string YS_GM_GBLJSTJ { get; set; }

        /// <summary>
        /// 高标准基本农田任务所属年度
        /// </summary>
        public string YS_GM_GBZND { get; set; }

        /// <summary>
        /// 新增耕地中旱地面积
        /// </summary>
        public decimal? YS_GM_HDMJ { get; set; }

        /// <summary>
        /// 核减前新增耕地面积
        /// </summary>
        public decimal? YS_GM_HJQXZGDMJ { get; set; }

        /// <summary>
        /// 基本农田整理规模（公顷）
        /// </summary>
        public decimal? YS_GM_JBNTZL { get; set; }

        /// <summary>
        /// 减少建设用地而增加耕地面积（公顷）
        /// </summary>
        public decimal? YS_GM_JSJSYDZJGDMJ { get; set; }

        /// <summary>
        /// 开发规模（公顷）
        /// </summary>
        public decimal? YS_GM_KF { get; set; }

        /// <summary>
        /// 新增耕地中水浇地面积
        /// </summary>
        public decimal? YS_GM_SJDMJ { get; set; }

        /// <summary>
        /// 新增耕地中水土面积
        /// </summary>
        public decimal? YS_GM_STMJ { get; set; }

        /// <summary>
        /// 用于农业土地开发的土地出让收入新增耕面积
        /// </summary>
        public decimal? YS_GM_XZGD_CRJXZGD { get; set; }

        /// <summary>
        /// 地方留成新增费资金新增耕地面积
        /// </summary>
        public decimal? YS_GM_XZGD_DFLCXZFXZGD { get; set; }

        /// <summary>
        /// 土地复垦义务人投资新增耕面积
        /// </summary>
        public decimal? YS_GM_XZGD_FKYWRTZXZGD { get; set; }

        /// <summary>
        /// 耕地开垦费新增耕地面积
        /// </summary>
        public decimal? YS_GM_XZGD_GDKKFXZGD { get; set; }

        /// <summary>
        /// 实际可用于占补平衡面积
        /// </summary>
        public decimal? YS_GM_XZGD_KYYZBPH { get; set; }

        /// <summary>
        /// 其他资金新增耕地面积
        /// </summary>
        public decimal? YS_GM_XZGD_QTZJXZGD { get; set; }

        /// <summary>
        /// 土地复垦费新增耕面积
        /// </summary>
        public decimal? YS_GM_XZGD_TDFKXZGD { get; set; }

        /// <summary>
        /// 自行补充耕地资金新增耕地面积
        /// </summary>
        public decimal? YS_GM_XZGD_ZXBCGDZJXZGD { get; set; }

        /// <summary>
        /// 中央分配的新增费资金新增耕地面积
        /// </summary>
        public decimal? YS_GM_XZGD_ZYFPXZFXZGD { get; set; }

        /// <summary>
        /// 中央支持的资金新增耕地面积
        /// </summary>
        public decimal? YS_GM_XZGD_ZYZCZJXZGD { get; set; }

        /// <summary>
        /// 实际新增耕地面积（公顷）
        /// </summary>
        public decimal? YS_GM_XZGDMJ { get; set; }

        /// <summary>
        /// 实际新增其他农用地面积（公顷）
        /// </summary>
        public decimal? YS_GM_XZQTNYDMJ { get; set; }

        /// <summary>
        /// 实际建设总规模（公顷）
        /// </summary>
        public decimal? YS_GM_ZGM { get; set; }

        /// <summary>
        /// 灾后恢复耕地面积
        /// </summary>
        public decimal? YS_GM_ZHHFGDMJ { get; set; }

        /// <summary>
        /// 项目区综合利用等别
        /// </summary>
        public string YS_GM_ZHLYDB { get; set; }

        /// <summary>
        /// 整理规模（公顷）
        /// </summary>
        public decimal? YS_GM_ZL { get; set; }

        /// <summary>
        /// 整理后建设用地面积（公顷）
        /// </summary>
        public decimal? YS_GM_ZLHJSYDMJ { get; set; }

        /// <summary>
        /// 整理前建设用地面积（公顷）
        /// </summary>
        public decimal? YS_GM_ZLQJSYDMJ { get; set; }

        /// <summary>
        /// 整治后耕地面积
        /// </summary>
        public decimal? YS_GM_ZZHGDMJ { get; set; }

        /// <summary>
        /// 改造产能指标
        /// </summary>
        public decimal? YS_GZ_CNZB { get; set; }

        /// <summary>
        /// 改造后平均质量等别
        /// </summary>
        public decimal? YS_GZ_HPJDB { get; set; }

        /// <summary>
        /// 提质改造面积
        /// </summary>
        public decimal? YS_GZ_MJ { get; set; }

        /// <summary>
        /// 改造前平均质量等别
        /// </summary>
        public decimal? YS_GZ_QPJDB { get; set; }

        /// <summary>
        /// 改造水浇地面积
        /// </summary>
        public decimal? YS_GZ_SJDMJ { get; set; }

        /// <summary>
        /// 改造水田面积
        /// </summary>
        public decimal? YS_GZ_STMJ { get; set; }

        /// <summary>
        /// 历史已占用面积
        /// </summary>
        public decimal? YS_LSYZYMJ { get; set; }

        /// <summary>
        /// 田块归并度（%）
        /// </summary>
        public decimal? YS_QSGL_GBD { get; set; }

        /// <summary>
        /// null
        /// </summary>
        public decimal? YS_QSGL_GYTDSYQ { get; set; }

        /// <summary>
        /// 国有土地所有权涉及的土地面积
        /// </summary>
        public decimal? YS_QSGL_GYTDSYQ_TDMJ { get; set; }

        /// <summary>
        /// null
        /// </summary>
        public decimal? YS_QSGL_JSYDSYQ { get; set; }

        /// <summary>
        /// 建设用地使用权涉及的土地面积
        /// </summary>
        public decimal? YS_QSGL_JSYDSYQ_TDMJ { get; set; }

        /// <summary>
        /// 权属调整类型
        /// </summary>
        public string YS_QSGL_LX { get; set; }

        /// <summary>
        /// null
        /// </summary>
        public decimal? YS_QSGL_NCJTTDSYQ { get; set; }

        /// <summary>
        /// 农村集体土地所有权
        /// </summary>
        public decimal? YS_QSGL_NCJTTDSYQ_TDMJ { get; set; }

        /// <summary>
        /// 权属调整实施主体
        /// </summary>
        public string YS_QSGL_SSZT { get; set; }

        /// <summary>
        /// 权属调整涉及的土地所有权总面积
        /// </summary>
        public decimal? YS_QSGL_SUYQZMJ { get; set; }

        /// <summary>
        /// 权属调整涉及的土地使用权总面积
        /// </summary>
        public decimal? YS_QSGL_SYQZMJ { get; set; }

        /// <summary>
        /// 权属调整涉及的土地比例
        /// </summary>
        public decimal? YS_QSGL_TDBL { get; set; }

        /// <summary>
        /// null
        /// </summary>
        public decimal? YS_QSGL_TDCBJYQ { get; set; }

        /// <summary>
        /// 土地承包经营权涉及的土地面积
        /// </summary>
        public decimal? YS_QSGL_TDCBJYQ_TDMJ { get; set; }

        /// <summary>
        /// 权属调整涉及的土地面积
        /// </summary>
        public decimal? YS_QSGL_TDMJ { get; set; }

        /// <summary>
        /// null
        /// </summary>
        public decimal? YS_QSGL_TDTXQL { get; set; }

        /// <summary>
        /// 土地他项权涉及的土地面积
        /// </summary>
        public decimal? YS_QSGL_TDTXQL_TDMJ { get; set; }

        /// <summary>
        /// 土地权属调整比例
        /// </summary>
        public decimal? YS_QSGL_TZBL { get; set; }

        /// <summary>
        /// null
        /// </summary>
        public decimal? YS_QSGL_ZJDSYQ { get; set; }

        /// <summary>
        /// 宅基地使用权涉及的土地面积
        /// </summary>
        public decimal? YS_QSGL_ZJDSYQ_TDMJ { get; set; }

        /// <summary>
        /// 权属调整涉及的总面积
        /// </summary>
        public decimal? YS_QSGL_ZMJ { get; set; }

        /// <summary>
        /// 整治后田块数量
        /// </summary>
        public long YS_QSGL_ZZHTKSL { get; set; }

        /// <summary>
        /// 整治前田块数量
        /// </summary>
        public long YS_QSGL_ZZQTKSL { get; set; }

        /// <summary>
        /// 是否历史已占用
        /// </summary>
        public decimal? YS_SFLSYZY { get; set; }

        /// <summary>
        /// 用于农业土地开发的土地出让收入（万元）
        /// </summary>
        public decimal? YS_TZ_DF_CRJ { get; set; }

        /// <summary>
        /// 地方留成新增费资金（万元）
        /// </summary>
        public decimal? YS_TZ_DF_DFLCXZF { get; set; }

        /// <summary>
        /// 土地复垦费（万元）
        /// </summary>
        public decimal? YS_TZ_DF_FKF { get; set; }

        /// <summary>
        /// 土地复垦义务人投资（万元）
        /// </summary>
        public decimal? YS_TZ_DF_FKYWRTZ { get; set; }

        /// <summary>
        /// 耕地开垦费（万元）
        /// </summary>
        public decimal? YS_TZ_DF_GDKKF { get; set; }

        /// <summary>
        /// 自行补充耕地资金（万元）
        /// </summary>
        public decimal? YS_TZ_DF_ZXBCGDZJ { get; set; }

        /// <summary>
        /// 中央分配的新增费资金（万元）
        /// </summary>
        public decimal? YS_TZ_DF_ZYFPXZF { get; set; }

        /// <summary>
        /// 地方资金
        /// </summary>
        public decimal? YS_TZ_DFZJ { get; set; }

        /// <summary>
        /// 灌溉与排水工程（中央支持）
        /// </summary>
        public decimal? YS_TZ_GC_GGPS { get; set; }

        /// <summary>
        /// 农田防护和生态环境保持工程（中央支持）
        /// </summary>
        public decimal? YS_TZ_GC_NLFH { get; set; }

        /// <summary>
        /// 其他工程（中央支持）
        /// </summary>
        public decimal? YS_TZ_GC_QTGC { get; set; }

        /// <summary>
        /// 土地平整工程（中央支持）
        /// </summary>
        public decimal? YS_TZ_GC_TDPZ { get; set; }

        /// <summary>
        /// 田间道路工程（中央支持）
        /// </summary>
        public decimal? YS_TZ_GC_TJDL { get; set; }

        /// <summary>
        /// 工程施工费（中央支持）
        /// </summary>
        public decimal? YS_TZ_GCSGF { get; set; }

        /// <summary>
        /// 项目结余资金（中央支持）
        /// </summary>
        public decimal? YS_TZ_JYZJ { get; set; }

        /// <summary>
        /// 拆迁补偿费（中央支持）
        /// </summary>
        public decimal? YS_TZ_QT_CQBCF { get; set; }

        /// <summary>
        /// 财政（中央支持）
        /// </summary>
        public decimal? YS_TZ_QT_CZ { get; set; }

        /// <summary>
        /// 工程监理费（中央支持）
        /// </summary>
        public decimal? YS_TZ_QT_GCJLF { get; set; }

        /// <summary>
        /// 环保（中央支持）
        /// </summary>
        public decimal? YS_TZ_QT_HB { get; set; }

        /// <summary>
        /// 竣工验收费（中央支持）
        /// </summary>
        public decimal? YS_TZ_QT_JGYSF { get; set; }

        /// <summary>
        /// 竣工验收费_标识设定费
        /// </summary>
        public decimal? YS_TZ_QT_JGYSF_BSSDF { get; set; }

        /// <summary>
        /// 竣工验收费_工程复核费
        /// </summary>
        public decimal? YS_TZ_QT_JGYSF_GCFHF { get; set; }

        /// <summary>
        /// 竣工验收费_工程验收费
        /// </summary>
        public decimal? YS_TZ_QT_JGYSF_GCYSF { get; set; }

        /// <summary>
        /// 竣工验收费_项目决算编制与审计费
        /// </summary>
        public decimal? YS_TZ_QT_JGYSF_XMJSBZYSJF { get; set; }

        /// <summary>
        /// 竣工验收费_整理后土地重估与登记费
        /// </summary>
        public decimal? YS_TZ_QT_JGYSF_ZLHTDCGYDJF { get; set; }

        /// <summary>
        /// 建设（中央支持）
        /// </summary>
        public decimal? YS_TZ_QT_JS { get; set; }

        /// <summary>
        /// 交通（中央支持）
        /// </summary>
        public decimal? YS_TZ_QT_JT { get; set; }

        /// <summary>
        /// 林业（中央支持）
        /// </summary>
        public decimal? YS_TZ_QT_LY { get; set; }

        /// <summary>
        /// 农业（中央支持）
        /// </summary>
        public decimal? YS_TZ_QT_NY { get; set; }

        /// <summary>
        /// 前期工作费（中央支持）
        /// </summary>
        public decimal? YS_TZ_QT_QQGZF { get; set; }

        /// <summary>
        /// 前期工作费_土地清查费
        /// </summary>
        public decimal? YS_TZ_QT_QQGZF_TDQCF { get; set; }

        /// <summary>
        /// 项目勘测费
        /// </summary>
        public decimal? YS_TZ_QT_QQGZF_XMKCF { get; set; }

        /// <summary>
        /// 项目可行性研究费
        /// </summary>
        public decimal? YS_TZ_QT_QQGZF_XMKXXYJF { get; set; }

        /// <summary>
        /// 项目设计与预算编制费
        /// </summary>
        public decimal? YS_TZ_QT_QQGZF_XMSJYYSBZF { get; set; }

        /// <summary>
        /// 项目招标代理费
        /// </summary>
        public decimal? YS_TZ_QT_QQGZF_XMZBDLF { get; set; }

        /// <summary>
        /// 其他资金（中央支持）
        /// </summary>
        public decimal? YS_TZ_QT_QTZJ { get; set; }

        /// <summary>
        /// 水利（中央支持）
        /// </summary>
        public decimal? YS_TZ_QT_SL { get; set; }

        /// <summary>
        /// 业主管理费（中央支持）
        /// </summary>
        public decimal? YS_TZ_QT_YZGLF { get; set; }

        /// <summary>
        /// 其他费用（中央支持）
        /// </summary>
        public decimal? YS_TZ_QTFY { get; set; }

        /// <summary>
        /// 其他涉农资金（中央支持自动计划，一般项目手动填写）
        /// </summary>
        public decimal? YS_TZ_QTZJ { get; set; }

        /// <summary>
        /// 设备购置费（中央支持）
        /// </summary>
        public decimal? YS_TZ_SBGZF { get; set; }

        /// <summary>
        /// 实际总投资（万元）
        /// </summary>
        public decimal? YS_TZ_ZTZ { get; set; }

        /// <summary>
        /// 中央支持的资金（万元）
        /// </summary>
        public decimal? YS_TZ_ZYZCZJ { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        public string YS_XMBH { get; set; }

        /// <summary>
        /// 新增产能指标
        /// </summary>
        public decimal? YS_XZGD_CNZB { get; set; }

        /// <summary>
        /// 新增耕地中旱地面积(跟部里面字段一致)
        /// </summary>
        public decimal? YS_XZGD_HDMJ { get; set; }

        /// <summary>
        /// 新增耕地平均质量等别
        /// </summary>
        public decimal? YS_XZGD_PJZLDB { get; set; }

        /// <summary>
        /// 新增耕地中水浇地面积(跟部里面字段一致)
        /// </summary>
        public decimal? YS_XZGD_SJDMJ { get; set; }

        /// <summary>
        /// 新增耕地中水土面积(跟部里面字段一致)
        /// </summary>
        public decimal? YS_XZGD_STMJ { get; set; }

        /// <summary>
        /// null
        /// </summary>
        public string YS_XZGDFL { get; set; }

        /// <summary>
        /// 验收单位
        /// </summary>
        public string YS_YSDW { get; set; }

        /// <summary>
        /// 验收日期
        /// </summary>
        public DateTime YS_YSRQ { get; set; }

        /// <summary>
        /// 验收文号
        /// </summary>
        public string YS_YSWH { get; set; }

        /// <summary>
        /// 验收文号_单位
        /// </summary>
        public string YS_YSWH1 { get; set; }

        /// <summary>
        /// 验收文号_年度
        /// </summary>
        public string YS_YSWH2 { get; set; }

        /// <summary>
        /// 验收文号_流水号
        /// </summary>
        public string YS_YSWH3 { get; set; }

        /// <summary>
        /// 坐标检查是否通过(0:否,1:是)
        /// </summary>
        public string YS_ZBJC_SFTG { get; set; }

    }
}